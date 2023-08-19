﻿using System;
using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.MiddleWare
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;
		private readonly IHostEnvironment _env;

		public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
		{
			_next = next;
			_logger = logger;
			_env = env;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				context.Response.ContentType = "Application/json";
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				var response = _env.IsDevelopment() ? new ApiException((int)HttpStatusCode.InternalServerError,
					ex.Message, ex.StackTrace.ToString()) : new ApiException((int)HttpStatusCode.InternalServerError);

				var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

				var json = JsonSerializer.Serialize(response,option);

				await context.Response.WriteAsync(json);
			}
		}

	}
}


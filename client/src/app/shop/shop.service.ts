import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/IPagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs';
import { ShopParams } from '../shared/models/ShopParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:7006/api/';

  constructor(private http: HttpClient) {}



  getProducts(shopParams:ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId) {
      params = params.append('brandId', shopParams.brandId.toString());
    }

    if (shopParams.typeId) {
      params = params.append('typeId', shopParams.typeId.toString());
    }

    if (shopParams.sort) {
      params = params.append('sort', shopParams.sort);
    }

    if (shopParams.search) {
      params=params.append('search',shopParams.search);
      
    }
    return this.http.get<IPagination>(this.baseUrl + 'Home', { observe: 'response', params }).pipe(
      map(response => {
        return response.body;
      })
    );
}


  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'Home/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'Home/types');
  }
}

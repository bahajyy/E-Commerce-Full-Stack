import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../shared/models/IProduct';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'; 
import { ShopParams } from '../shared/models/ShopParams';


@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
})
export class ShopComponent implements OnInit {
  @ViewChild('search',{static:true}) searchTerm : ElementRef | undefined;

  products: IProduct[] | undefined;
  brands: IBrand[] | undefined;
  types: IType[] | undefined;
  shopParams = new ShopParams();
  brandIdSelected  =0;
  typeIdSelected =0;
  sortSelected='name';
  sortOptions=[
    {name:"Alphabetical",value:'name'},
    {name:"Price Low to High",value:'priceAsc'},
    {name:"Price High to Low ",value:'priceDesc'}
  ]


  constructor(private shopService: ShopService,private modalService: NgbModal) {}

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe(
      (response) => {
        this.products = response?.data;
        console.log(this.products);
      },
      (err) => {
        console.log(err);
      }
    );
  }
  
  getBrands() {
    this.shopService.getBrands().subscribe(
      (response) => {
        var firstItem={id:0,name:'All'}
        this.brands = [firstItem,...response];
      },
      (err) => {
        console.log(err);
      }
    );
  }

  getTypes() {
    this.shopService.getTypes().subscribe(
      (response) => {
        var firstItem={id:0,name:'All'}
        this.types = [firstItem,...response];
      },
      (err) => {
        console.log(err);
      }
    );
  }

  onBrandSelected(brandId:number){
    this.shopParams.brandId=brandId;
    this.getProducts();
  }

  onTypeSelected(typeId:number){
    this.shopParams.typeId=typeId;
    this.getProducts();
  }

  onSortSelected(event: Event) {
    const selectedValue = (event.target as HTMLSelectElement).value;
    this.shopParams.sort = selectedValue;
    this.getProducts();
  }

  onSearch(){
    this.shopParams.search=this.searchTerm?.nativeElement.value;
    this.getProducts();

  }

  onReset(){
    this.searchTerm?.nativeElement.value;
    this.shopParams=new ShopParams();
    this.getProducts();

  }

  


  

}

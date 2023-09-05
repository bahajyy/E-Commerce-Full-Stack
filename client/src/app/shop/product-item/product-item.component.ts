import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/IProduct';
import { ProductModalComponent } from 'src/app/product-modal/product-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'; 

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  @Input() product: IProduct | undefined;

  constructor(private modalService: NgbModal) {}

  ngOnInit(): void {
    // ngOnInit içeriği
  }

  openProductModal(product: IProduct) {
    const modalRef = this.modalService.open(ProductModalComponent);
    modalRef.componentInstance.product = product;
  }
}

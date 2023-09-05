import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IProduct } from '../shared/models/IProduct';



@Component({
  selector: 'app-product-modal',
  template: `
    <div class="modal-header">
      <h4 class="modal-title">{{ product.name }}</h4>
      <button type="button" class="close" aria-label="Close" (click)="activeModal.dismiss()">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">
      <p>{{ product.description }}</p>
      <p>Price: {{ product.price +" $"}}</p>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-secondary" (click)="activeModal.close('Close click')">Close</button>
    </div>
  `,
})
export class ProductModalComponent {
  @Input() product!: IProduct;

  constructor(public activeModal: NgbActiveModal) {}
}

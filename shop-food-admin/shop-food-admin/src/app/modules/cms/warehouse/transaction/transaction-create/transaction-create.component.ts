import { NgFor } from '@angular/common';
import { Component, ElementRef, Renderer2 } from '@angular/core';
import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  FormArray,
  Validators,
  FormControl,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import {
  SubTransactionWhCreateModelReq,
  SupplierWhListModelRes,
  TransactionWhCreateModelReq,
  UnitWhListModelRes,
  UnitWhModel,
  WarehouseService,
} from '../../../../../services/warehouse-service.service';
import {
  PageingReq,
  StatusCodeApiResponse,
} from '../../../../../commons/const/ConstStatusCode';
import { CommonServiceService } from '../../../../../services/common-service.service';

@Component({
  selector: 'app-transaction-create',
  standalone: true,
  imports: [NgFor, ReactiveFormsModule],
  templateUrl: './transaction-create.component.html',
  styleUrl: './transaction-create.component.scss',
})
export class TransactionCreateComponent {
  supplierList: SupplierWhListModelRes = {};
  myForm: FormGroup;
  transactionCode = new FormControl('');
  transactionDate = new FormControl('');
  supplierId = new FormControl('');
  listTransDetail: any[] = [];
  listUnit: UnitWhModel[] = [];
  totalPriceDetail = new FormControl('');

  constructor(
    private readonly _warehouseService: WarehouseService,
    private readonly _router: Router,
    private readonly _toastService: ToastrService,
    private readonly _renderer: Renderer2,
    private readonly _el: ElementRef,
    private readonly fb: FormBuilder,
    private readonly _commonService: CommonServiceService
  ) {
    this.myForm = this.fb.group({
      items: this.fb.array([]),
    });
  }

  ngOnInit(): void {
    this.listSupplier();
    this.getListUnit();
  }

  listSupplier() {
    this._warehouseService
      .listSupplier({
        pageNumber: PageingReq.PAGE_NUMBER,
        pageSize: PageingReq.PAGE_SIZE,
      })
      .subscribe((res) => {
        if (res.isNormal) {
          this.supplierList = res.data ?? {};
        }
      });
  }

  get items(): FormArray {
    return this.myForm.get('items') as FormArray;
  }

  addItem() {
    const itemFormGroup = this.fb.group({
      productId: [''],
      barCode: [''],
      productName: [''],
      unitId: [''],
      quantity: [''],
      unitPrice: [''],
      totalAmount: [''],
    });

    this.items.push(itemFormGroup);
  }

  removeItem(index: number) {
    this.items.removeAt(index);
    this.listTransDetail.splice(index);
  }

  onRewrite(index: any, name: any, isId: boolean = false) {
    return isId ? `${name}_${index}_id` : `${name}_${index}_name`;
  }

  onCancel() {
    this._router.navigate(['/wh/transaction']);
  }

  getListUnit() {
    this._warehouseService
      .listUnit({
        pageNumber: PageingReq.PAGE_NUMBER,
        pageSize: PageingReq.PAGE_SIZE,
      })
      .subscribe((res) => {
        if (res.isNormal) {
          this.listUnit = res.data?.list ?? [];
        }
      });
  }

  onSearchProduct(i: any) {
    const barCode = this.myForm.value['items'][i]['barCode'];
    let index = this.listTransDetail.findIndex((x) => x.barCode == barCode);
    this._warehouseService
      .detailProduct({
        barCode: barCode,
      })
      .subscribe((res) => {
        if (
          res.isNormal &&
          res.metaData?.statusCode == StatusCodeApiResponse.SUCCESS
        ) {
          if (index >= 0) {
            this.listTransDetail.splice(i, 1);
          }
          this.listTransDetail.push({
            productId: res.data?.id,
            barCode: res.data?.barCode,
            productName: res.data?.name,
            unitId: res.data?.unitId,
            quantity: 1,
            unitPrice: this._commonService.formatCurrency(0),
            totalAmount: this._commonService.formatCurrency(1 * 0),
          });
          this.items.setValue(this.listTransDetail);
          this.calTotalAmountDetail();
        } else {
          this._toastService.error('Không tìm thấy sản phẩm');
          if (this.listTransDetail.length >= i) {
            this.listTransDetail.splice(i, 1);
            this.removeItem(i);
          }
        }
      });
  }

  onCalTotalAmount(i: any) {
    let quantity = this.myForm.value['items'][i]['quantity'];
    let unitPrice = this._commonService.revertFormatCurrency(
      this.myForm.value['items'][i]['unitPrice']
    );
    let totalAmount = quantity * unitPrice;
    let barCode = this.myForm.value['items'][i]['barCode'];
    let productId = this.myForm.value['items'][i]['productId'];
    let productName = '';
    let unitId = '';
    let index = this.listTransDetail.findIndex((x) => x.barCode == barCode);
    if (index >= 0) {
      barCode = this.listTransDetail[i]['barCode'];
      productName = this.listTransDetail[i]['productName'];
      unitId = this.listTransDetail[i]['unitId'];
      productId = this.listTransDetail[i]['productId'];
      this.listTransDetail.splice(i, 1);
    }
    this.listTransDetail.splice(index, 0, {
      productId: productId,
      barCode: barCode,
      productName: productName,
      unitId: unitId,
      quantity: quantity,
      unitPrice: this._commonService.formatCurrency(unitPrice),
      totalAmount: this._commonService.formatCurrency(totalAmount),
    });
    this.items.setValue(this.listTransDetail);
    this.calTotalAmountDetail();
  }

  calTotalAmountDetail() {
    let totalPriceDetail = 0;
    this.listTransDetail.forEach((element: any, index: any) => {
      totalPriceDetail += this._commonService.revertFormatCurrency(
        element.totalAmount
      );
    });
    this.totalPriceDetail.setValue(
      this._commonService.formatCurrency(totalPriceDetail)
    );
  }

  onSave() {
    console.log('this.myForm.value :>> ', this.myForm.value);
    let details: SubTransactionWhCreateModelReq[] = [];
    this.myForm.value['items'].forEach((element: any) => {
      details.push({
        quantity: this._commonService.parseStringToInt(element.quantity),
        unitPrice: this._commonService.revertFormatCurrency(element.unitPrice),
        totalPrice: this._commonService.revertFormatCurrency(
          element.totalAmount
        ),
        productId: element.productId,
        dateOfExpired: null,
        dateOfManufacture: null,
      });
    });
    let request: TransactionWhCreateModelReq = {
      transactionDate: new Date(this.transactionDate.value ?? '') ?? null,
      transactionCode: this.transactionCode.value ?? null,
      transactionType: '0',
      totalPrice: this._commonService.revertFormatCurrency(
        this.totalPriceDetail.value
      ),
      details: details,
    };
    console.log('request :>> ', request);
    this._warehouseService.createTransaction(request).subscribe((res) => {
      if (
        res.isNormal &&
        res.metaData?.statusCode == StatusCodeApiResponse.SUCCESS
      ) {
        this._toastService.success('Tạo phiếu nhập thành công');
        this._router.navigate(['/wh/transaction']);
      } else {
        this._toastService.error('Tạo phiếu nhập thất bại');
      }
    });
  }
}

import { Injectable } from '@angular/core';
import { CustomerInformationDTO } from '../commons/ngrx/models';

@Injectable({
  providedIn: 'root'
})
export class CommonServiceService {

  _global_customer_infor: CustomerInformationDTO = {
    name: '',
    email: '',
    accessToken: '',
    expiredDate: new Date()
  };

  constructor() {
  }

  getGlobalCustomerInfor(): CustomerInformationDTO {
    return this._global_customer_infor;
  }

  setGlobalCustomerInfor(customerInfor: CustomerInformationDTO) {
    this._global_customer_infor = customerInfor;
  }
}

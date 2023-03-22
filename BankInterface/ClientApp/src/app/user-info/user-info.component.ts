import { Component } from '@angular/core';
import { BankAccountService } from '../bank-account.service';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent {
  customerID: number | null = null;
  userInfo: any;

  constructor(private BankAccountService: BankAccountService) { }

  getUserInfo(): void {
    if (this.customerID !== null) {
      this.BankAccountService.getUserInfo(this.customerID).subscribe((data) => {
        this.userInfo = data;
      });
    }
  }
}

import { Component } from '@angular/core';
import { BankAccountService } from '../bank-account.service';

@Component({
  selector: 'app-open-account',
  templateUrl: './open-account.component.html',
  styleUrls: ['./open-account.component.css']
})
export class OpenAccountComponent {
  customerID: number = 0;
  initialCredit: number = 0;
  newAccountId: number | null = null;


  constructor(private bankAccountService: BankAccountService) { }

  openAccount(): void {
    this.bankAccountService.openAccount(this.customerID, this.initialCredit).subscribe((accountId) => {
      this.newAccountId = accountId;
    });
  }
}

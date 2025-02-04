import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PaymentDialogComponent } from './payment-dialog/payment-dialog.component';
import { InvoiceService } from '../../Services/invoice.service';

@Component({
  selector: 'app-fee',
  templateUrl: './fee.component.html',
  styleUrls: ['./fee.component.css'],
})
export class FeeComponent implements OnInit {
  payments:any;

  constructor(private dialog: MatDialog, private _feeServ:InvoiceService) {}

  ngOnInit(): void {
    // Fetch payments data here
    this.getFeeDetails();
  }

  // Add a new payment
  // paymentAdd(paymentData:any): void {
  //   console.log('Add New Payment');
  //   this.dialog
  //     .open(PaymentDialogComponent, {
  //       width: 'auto',
  //       data: paymentData,
  //     })
  //     .afterClosed()
  //     .subscribe((res) => {
  //       if (res) {
  //       }
  //     });
  // }

  public detail(record:any){
    console.log(record)
  }

  getFeeDetails(){
    this._feeServ.getFeeDetails().subscribe((res:any)=>{
      if(res){
        console.log(res);
        this.payments=res;
      }
    })
  }
}

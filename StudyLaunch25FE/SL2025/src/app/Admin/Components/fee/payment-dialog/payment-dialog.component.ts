import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { InvoiceService } from 'src/app/admin/Services/invoice.service';

@Component({
  selector: 'app-payment-dialog',
  templateUrl: './payment-dialog.component.html',
  styleUrls: ['./payment-dialog.component.css']
})
export class PaymentDialogComponent implements OnInit{
  public dateCurrent=new Date().toISOString().split('T')[0];
  paymentMode:string='';
  amount:number=0;  
  constructor(
    private dialogRef: MatDialogRef<PaymentDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _invoiceserv:InvoiceService
  ){}


ngOnInit(): void {
  console.log(this.data);
  this.amount=this.data.amountToPay;
}

  savePayment(){
    let data={
      "amount": this.amount,
      "paymentDate": new Date(),
      "paymentStatus":this.paymentMode,
      "studentId": this.data.studentId,
      "studentName": "",
      "studentContact": ""
    }
    this._invoiceserv.postPaymentDetail(data).subscribe((res:any)=>{
      if(res){
        console.log(res);
        alert("Thanks ")
      }
    })
  }

}

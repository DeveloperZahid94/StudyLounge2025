import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { InvoiceService } from 'src/app/admin/Services/invoice.service';
// import html2pdf from 'html2pdf.js';
declare module 'html2pdf.js';
import html2pdf from 'html2pdf.js';
import { PaymentDialogComponent } from '../payment-dialog/payment-dialog.component';

@Component({
  selector: 'app-fee-detail-dialog',
  templateUrl: './fee-detail-dialog.component.html',
  styleUrls: ['./fee-detail-dialog.component.css']
})
export class FeeDetailDialogComponent implements OnInit{

  feeDetails:any;
  constructor(
    private dialog: MatDialog,
    private dialogRef: MatDialogRef<FeeDetailDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _feeDetailServ:InvoiceService
  ){}
ngOnInit(): void {
  console.log(this.data);
  this.getfeeDetail();
}

public getfeeDetail(){
  this._feeDetailServ.getFeeDetailById(this.data.studentId).subscribe((res:any)=>{
    if(res){
      console.log("feedetail",res);
      this.feeDetails=res;
    }
  })
}
downloadReceipt() {
  const element = document.getElementById('receipt-table');  // Get the table element
  const options = {
    margin:       1,
    filename:     'FeeReceipt.pdf',
    image:        { type: 'jpeg', quality: 0.98 },
    html2canvas:  { dpi: 192, letterRendering: true },
    jsPDF:        { unit: 'in', format: 'letter', orientation: 'portrait' }
  };
  
  // Generate and download the PDF
  html2pdf()
    .from(element)
    .set(options)
    .save();
}

// Add a new payment
  paymentAdd(paymentData:any): void { debugger
    paymentData.studentId=this.data.studentId
    paymentData.amountToPay=paymentData.totalFee-paymentData.feePaid
    console.log('Add New Payment');
    this.dialog
      .open(PaymentDialogComponent, {
        width: 'auto',
        data: paymentData,
      })
      .afterClosed()
      .subscribe((res) => {
        if (res) {
        }
      });
    }

    getHasBalance(totalFee:number,feePaid:number){
      return totalFee-feePaid>0?true:false;
    }
}

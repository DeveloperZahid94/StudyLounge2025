import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PaymentDialogComponent } from './payment-dialog/payment-dialog.component';

@Component({
  selector: 'app-fee',
  templateUrl: './fee.component.html',
  styleUrls: ['./fee.component.css'],
})
export class FeeComponent implements OnInit {
  payments = [
    {
      feeId: '1',
      studentName: 'John Doe',
      studentContact: '123-456-7890',
      amount: 100.5,
      paymentDate: new Date(),
      paymentStatus: 'Paid',
    },
    {
      feeId: '2',
      studentName: 'Jane Smith',
      studentContact: '987-654-3210',
      amount: 200.0,
      paymentDate: new Date(),
      paymentStatus: 'Pending',
    },
    // Add more payment objects as needed
  ];

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {
    // Fetch payments data here
  }

  // Add a new payment
  paymentAdd(paymentData:any): void {
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
}

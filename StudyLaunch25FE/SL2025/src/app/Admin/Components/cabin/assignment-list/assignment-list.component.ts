import { Component, OnInit } from '@angular/core';
import { AssignmentComponent } from '../assignment/assignment.component';
import { MatDialog } from '@angular/material/dialog';
import { AssignmentService } from 'src/app/Admin/Services/assignment.service';
import { PaymentDialogComponent } from '../../fee/payment-dialog/payment-dialog.component';

@Component({
  selector: 'app-assignment-list',
  templateUrl: './assignment-list.component.html',
  styleUrls: ['./assignment-list.component.css']
})
export class AssignmentListComponent implements OnInit {
constructor(
    private dialog: MatDialog,
    private _assignmentService:AssignmentService
  ){}
public assignments:any;
 
ngOnInit(): void {
  this.getAllAssignments();
}
// Open the dialog for adding a new assignment
public assignmentAdd() {
  this.editAssignment(null); 
}

// Open the dialog for editing an existing assignment
public editAssignment(assignment: any) {
  this.dialog.open(AssignmentComponent, {
    width: '50%',
    data: assignment 
  }).afterClosed().subscribe((res:any) => {
    if (res) {
      this.getAllAssignments(); 
     
    }
  });
}
deleteAssignment(assignmentId:any){
  this._assignmentService.deleteAssignment(assignmentId).subscribe((res:any)=>{
      if(res){
        alert("deleted");
      }
  })
}

// Refresh the assignments list from the server
getAllAssignments() {
  this._assignmentService.getAssignments().subscribe((res:any)=>{
    if(res){
      this.assignments=res;
      console.log(res)
    }
  })
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

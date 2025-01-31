import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AssignmentService } from 'src/app/Admin/Services/assignment.service';
import { CabinService } from 'src/app/Admin/Services/cabin.service';
import { StudentService } from 'src/app/admin/Services/student.service';

@Component({
  selector: 'app-assignment',
  templateUrl: './assignment.component.html',
  styleUrls: ['./assignment.component.css']
})
export class AssignmentComponent implements OnInit{
  assignmentForm:any;
  students:any;
  cabins:any;


  constructor(
    public dialogRef: MatDialogRef<AssignmentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, 
    private _assignmentService: AssignmentService ,
    private _studentService:StudentService,
    private _cabinService:CabinService
    ) {}
  ngOnInit(): void {
    this.getStudents();
    this.getCabins();
    this.assignmentForm = new FormGroup({
      studentId: new FormControl(this.data ? this.data.studentId : ''),
      cabinId: new FormControl(this.data ? this.data.cabinId : ''),
      startDate: new FormControl(this.data ? this.formatDate(this.data.startDate) : ''),
      endDate: new FormControl(this.data ? this.formatDate(this.data.endDate) : ''),
      assignmentStatus: new FormControl(this.data ? this.data.assignmentStatus : 'Pending'),
    });
  }

  // Handle the form submission
  onSubmit() {
    let data = this.assignmentForm.value;
    if (this.data) {
      this.updateAssignment(this.data.assignmentId, data);
      return;
    }
    this._assignmentService.postAssignment(data).subscribe((res: any) => {
      if (res) {
        alert("Assignment added successfully!");
      }
    });
  }

  // Method to format date (if needed)
  formatDate(date: string | Date): string {
    if (!date) return '';
    const formattedDate = new Date(date);
    return formattedDate.toISOString().split('T')[0]; // Format as 'YYYY-MM-DD'
  }

  // Update existing assignment
  updateAssignment(assignmentId: any, data: any) {
    this._assignmentService.updateAssignment(assignmentId, data).subscribe((res) => {
      if (res) {
        alert("Assignment updated successfully!");
      }
    });
  }

  getStudents(){
    this._studentService.getStudents().subscribe((res:any)=>{
      if(res){
        this.students=res;
      }
    });
  }

  getCabins(){ 
    this._cabinService.getCabins().subscribe((res:any)=>{
      if(res){ 
        this.cabins=res;
      }
    });
  }

  /** 
   * Method To close Dialog  
  */  
  public closeDialog(){debugger
    this.dialogRef.close(true);
  }


}

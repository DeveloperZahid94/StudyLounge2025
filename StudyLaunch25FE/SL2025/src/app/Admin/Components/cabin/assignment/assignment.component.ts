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
  public assignmentForm:any;
  public students:any;
  public cabins:any;
  public rates:number=0;
  public minDate=new Date().toISOString().split('T')[0];


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
      assignmentStatus: new FormControl(this.data ? this.data.assignmentStatus : 'InActive'),
    });
    this.watchFormChanges();
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
        console.log(res);
        this.students=res.filter((val:any)=>val.status!='Assigned');
      }
    });
  }

  getCabins(){ 
    this._cabinService.getCabins().subscribe((res:any)=>{
      if(res){ 
        console.log(res);
        this.cabins=res;
      }
    });
  }

  // Function to watch for changes in the form controls
  watchFormChanges(): void {
    // Trigger calculation when cabin changes
    this.assignmentForm.get('cabinId')?.valueChanges.subscribe(() => {
      this.cabinChange();
    });

    // Trigger calculation when start date changes
    this.assignmentForm.get('startDate')?.valueChanges.subscribe(() => {
      this.cabinChange();
    });

    // Trigger calculation when end date changes
    this.assignmentForm.get('endDate')?.valueChanges.subscribe(() => {
      this.cabinChange();
    });
  }
 
  public cabinChange(){
    const selectedCabinId = this.assignmentForm.get('cabinId')?.value;
    const selectedCabin = this.cabins.find((cabin:any) => cabin.cabinId === selectedCabinId);

    if (selectedCabin) {
      this.calculateRate(selectedCabin.pricePerDay);
    }
  }

  public calculateRate(cabinRate: number){ debugger
    const startDate = this.assignmentForm.get('startDate')?.value;
    const endDate = this.assignmentForm.get('endDate')?.value;

    if (startDate && endDate) {
      const start = new Date(startDate);
      const end = new Date(endDate);

      const timeDifference = end.getTime() - start.getTime();
      const dayDifference = timeDifference / (1000 * 3600 * 24); // Convert milliseconds to days

      if (dayDifference >= 0) {
        this.rates = cabinRate * dayDifference;
      } else {
        this.rates = 0;
      }
    }
  }

  /** 
   * Method To close Dialog  
  */  
  public closeDialog(){debugger
    this.dialogRef.close(true);
  }


}

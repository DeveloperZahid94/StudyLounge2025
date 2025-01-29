import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { StudentService } from '../../Services/student.service';

@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrls: ['./student-add.component.css']
})
export class StudentAddComponent implements OnInit{
  studentForm: any;
  isEditMode: boolean = false;

  constructor(
    private dialogRef: MatDialogRef<StudentAddComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private _studentService:StudentService, 
  ) {}

  ngOnInit(): void {
    console.log(this.data)
    // Initialize the form with empty values
    this.studentForm = this.fb.group({
      firstName: [this.data ? this.data.firstName : '', Validators.required],
      lastName: [this.data ? this.data.lastName : '', Validators.required],
      email: [this.data ? this.data.email : '', [Validators.required, Validators.email]],
      phoneNumber: [this.data ? this.data.phoneNumber : '', [Validators.required, Validators.pattern('^[0-9]*$')]],
      status: [this.data ? this.data.status : '', Validators.required],
      address: [this.data ? this.data.address : ''],
      dateOfBirth: [this.data ? this.formatDate(this.data.dateOfBirth) : ''],
      registrationDate: [this.data ? this.formatDate(this.data.registrationDate) : '']
    });

  }


  onSubmit(): void {debugger
    // if (this.studentForm.invalid) {
    //   alert("form invalid")
    //   return;
    // }
    if(this.data){
      this.updateStudents(this.data.studentId,this.studentForm.value);
      return;
    }
    this._studentService.postStudents(this.studentForm.value).subscribe((res=>{
      if(res){
        alert("created")
      }
      console.log(res);
    }))
  }


  private updateStudents(id:any,data:any){
    this._studentService.updateStudents(id,data).subscribe((res=>{
      if(res){
        alert("updated");
        
      }
      console.log(res)
    }))
  }

  // Method to format date (if needed)
  formatDate(date: string | Date): string {
    if (!date) return '';
    const formattedDate = new Date(date);
    return formattedDate.toISOString().split('T')[0]; // Format as 'YYYY-MM-DD'
  }
  /** 
   * Method To close Dialog  
  */  
  public closeDialog(){
    this.dialogRef.close(true);
  }
}

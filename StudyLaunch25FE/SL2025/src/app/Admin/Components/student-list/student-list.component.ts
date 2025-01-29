import { Component, OnInit } from '@angular/core';
import { StudentService } from '../../Services/student.service';
import { MatDialog } from '@angular/material/dialog';
import { StudentAddComponent } from '../student-add/student-add.component';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  students:any;
  constructor(
    private _studentserv:StudentService,
    private dialog: MatDialog,
  ) { }

ngOnInit(): void {
  this.getAllStudents();
}

public editStudent(student:any): void {
  this.dialog.open(StudentAddComponent,{
    width: 'auto',
    data:student
    }).afterClosed().subscribe(res => {
     if(res){ 
      this.getAllStudents();
      this.dialog.closeAll();
     }   
   });
}

private getAllStudents(){
  this._studentserv.getStudents().subscribe((res:any)=>{
    this.students=res;
    console.log(res);
  })
}

  

  deleteStudent(studentId: string): void {
    if (confirm('Are you sure you want to delete this student?')) {
      this._studentserv.deleteStudents(studentId).subscribe((res) => {
        if(res){
          alert("Record deleted ");
          this.getAllStudents();
        }
        
      });
    }
  }

  

}

import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/admin/Services/student.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  searchTxt:string='';
  studentRecord:any;
  constructor(private _studentServ:StudentService){}
  ngOnInit(): void {
    
  }

  getDetail(){ debugger
    this._studentServ.getStudentSearch(this.searchTxt).subscribe((res:any)=>{
      if(res){
        this.studentRecord=res;
        console.log(res);
      }
    })
  }

  detail(student:any){
    console.log(student)
  }

}

import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddCabinComponent } from '../add-cabin/add-cabin.component';
import { CabinService } from 'src/app/Admin/Services/cabin.service';

@Component({
  selector: 'app-cabin-list',
  templateUrl: './cabin-list.component.html',
  styleUrls: ['./cabin-list.component.css']
})
export class CabinListComponent implements OnInit {
  public cabins:any;
  constructor(
    private dialog: MatDialog,
    private _cabinservice:CabinService
  ){}
  ngOnInit(): void {
    this.getAllCabins();
  }
  public cabinAdd(){
    this.editCabin(null);
  }
  public editCabin(cabin:any){
    this.dialog.open(AddCabinComponent,{
        width: '50%',
        data:cabin
        }).afterClosed().subscribe(res => {
         if(res){ 
          this.getAllCabins();
         }   
       });
  }
  public deleteCabin(cabinId:any){
    if (confirm('Are you sure you want to delete this cabin?')) {
      this._cabinservice.deleteCabins(cabinId).subscribe((res) => {
        if(res){
          alert("Record deleted ");
          this.getAllCabins();
        }
      });
    }
  }

  public getAllCabins(){
    this._cabinservice.getCabins().subscribe((res:any)=>{
      if(res){
        this.cabins=res;
        console.log(res);
      }
    })
  }
}

import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CabinService } from 'src/app/Admin/Services/cabin.service';

@Component({
  selector: 'app-add-cabin',
  templateUrl: './add-cabin.component.html',
  styleUrls: ['./add-cabin.component.css']
})
export class AddCabinComponent implements OnInit {
  cabinForm: any;
  constructor(
    private dialogRef: MatDialogRef<AddCabinComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _cabinservice:CabinService
  ){}

  ngOnInit(): void {
    this.cabinForm = new FormGroup({
      cabinName: new FormControl(this.data ? this.data.cabinName : ''),
      description: new FormControl(this.data ? this.data.description : ''),
      hasWifi: new FormControl(this.data ? this.data.hasWifi : null),
      hasAc: new FormControl(this.data ? this.data.hasAc : null),
      isAvailable: new FormControl(this.data ? this.data.isAvailable : null),
      pricePerDay: new FormControl(this.data ? this.data.pricePerDay : null),
    });
    
  }

  // Handle the form submission
  onSubmit() {
    let data=this.cabinForm.value;
    if(this.data){
      this.updateCabin(this.data.cabinId,data);
      return;
    }  
    this._cabinservice.postCabins(data).subscribe((res:any)=>{
      if(res){
        alert("data submitted")
      }
    })
  }

   updateCabin(cabinId:any,data:any){
    this._cabinservice.updateCabins(cabinId,data).subscribe((res=>{
      if(res){
        alert("updated");
        
      }
      console.log(res)
    }))
   }

  /** 
   * Method To close Dialog  
  */  
  public closeDialog(){
    this.dialogRef.close(true);
  }
}

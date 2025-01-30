import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { StudentAddComponent } from './Components/student-add/student-add.component';
import { StudentListComponent } from './Components/student-list/student-list.component';
import { AddCabinComponent } from './Components/cabin/add-cabin/add-cabin.component';
import { CabinListComponent } from './Components/cabin/cabin-list/cabin-list.component';

const routes: Routes = [
  { path: 'student', component: StudentAddComponent },
  { path: 'viewStudent', component: StudentListComponent },

  {path:'cabin' ,component:AddCabinComponent},
  {path:'viewCabin',component:CabinListComponent}
  // { path: '**', component: StudentListComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }

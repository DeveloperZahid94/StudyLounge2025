import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { StudentAddComponent } from './Components/student-add/student-add.component';
import { StudentListComponent } from './Components/student-list/student-list.component';

const routes: Routes = [
  { path: 'student', component: StudentAddComponent },
  { path: 'viewStudent', component: StudentListComponent },
  // { path: '**', component: StudentListComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }

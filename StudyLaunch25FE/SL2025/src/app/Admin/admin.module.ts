import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { StudentAddComponent } from './Components/student-add/student-add.component';
import { StudentListComponent } from './Components/student-list/student-list.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AdminComponent,
    StudentAddComponent,
    StudentListComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
       MatToolbarModule,
        MatButtonModule,
        MatIconModule,
        MatSidenavModule,
        ReactiveFormsModule,
        
  ]
})
export class AdminModule { }

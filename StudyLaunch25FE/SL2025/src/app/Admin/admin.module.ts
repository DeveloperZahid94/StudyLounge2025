import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { StudentAddComponent } from './Components/student-add/student-add.component';
import { StudentListComponent } from './Components/student-list/student-list.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatRadioModule } from '@angular/material/radio';
import {MatStepperModule} from '@angular/material/stepper';
import {MatCardModule} from '@angular/material/card';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MatTooltipModule } from '@angular/material/tooltip';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { LayoutModule } from '../layout/layout.module';
import { MatDividerModule } from '@angular/material/divider';
import { MatSortModule } from '@angular/material/sort';
import { AddCabinComponent } from './Components/cabin/add-cabin/add-cabin.component';
import { CabinListComponent } from './Components/cabin/cabin-list/cabin-list.component';
import { AssignmentComponent } from './Components/cabin/assignment/assignment.component';
import { FeeComponent } from './Components/fee/fee.component';
import { ReportsComponent } from './Components/reports/reports.component';
import { AssignmentListComponent } from './Components/cabin/assignment-list/assignment-list.component';
import { InvoiceComponent } from './Components/fee/invoice/invoice.component';
import { PaymentDialogComponent } from './Components/fee/payment-dialog/payment-dialog.component';
import { FeeDetailDialogComponent } from './Components/fee/fee-detail-dialog/fee-detail-dialog.component';
import { SearchComponent } from './Components/reports/search/search.component';



@NgModule({
  declarations: [
    AdminComponent,
    StudentAddComponent,
    StudentListComponent,
    AddCabinComponent,
    CabinListComponent,
    AssignmentComponent,
    FeeComponent,
    ReportsComponent,
    AssignmentListComponent,
    InvoiceComponent,
    PaymentDialogComponent,
    FeeDetailDialogComponent,
    SearchComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,ReactiveFormsModule,MatButtonToggleModule,
    MatInputModule,MatFormFieldModule,MatCheckboxModule,
    MatSelectModule,MatIconModule,MatButtonModule,
    MatDialogModule,MatRadioModule,MatStepperModule,
    MatPaginatorModule, MatTableModule,MatCardModule,
    MatTooltipModule,MatDividerModule,MatSortModule,
    LayoutModule,
        
  ]
})
export class AdminModule { }

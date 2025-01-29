import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';

import {MatListModule} from '@angular/material/list';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatMenuModule} from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {MatSidenavModule} from '@angular/material/sidenav';
import { AdminRoutingModule } from '../admin/admin-routing.module';
import { SideNavComponent } from './side-nav/side-nav.component';


@NgModule({
  declarations: [
    SideNavComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule,
    MatToolbarModule,MatIconModule,MatButtonModule,
    MatSidenavModule,MatListModule,MatExpansionModule,MatMenuModule,
    MatSelectModule,MatFormFieldModule,
    AdminRoutingModule
  ],
  exports: [
    HeaderComponent,
    SideNavComponent
  ]
})
export class LayoutModule { }

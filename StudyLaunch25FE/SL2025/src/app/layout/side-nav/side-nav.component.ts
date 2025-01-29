import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit{
  isSidebarOpen = true;
  isExpanded=false;


  constructor() {}

  ngOnInit() {
    this.checkScreenSize();
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: Event) {
    this.checkScreenSize();
  }

  checkScreenSize() {
    this.isExpanded = window.innerWidth >= 600;
  }
  
  toggleSidebar() {
    this.isExpanded = !this.isSidebarOpen;
  }
}

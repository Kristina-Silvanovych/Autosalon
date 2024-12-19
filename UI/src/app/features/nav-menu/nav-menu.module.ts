import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatMenuModule } from '@angular/material/menu';  
import { NavMenuComponent } from './components/nav-menu.component';  

@NgModule({
  declarations: [NavMenuComponent],  
  imports: [
    CommonModule,
    RouterModule,  
    MatMenuModule  
  ],
  exports: [NavMenuComponent]  
})
export class NavMenuModule { }


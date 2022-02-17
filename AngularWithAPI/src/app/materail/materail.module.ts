import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import{MatIconModule}from '@angular/material/icon';


const Material =[
  MatButtonModule,
  MatTableModule,
  MatIconModule
]; 


@NgModule({
  imports: [ Material ],
  exports: [ Material]
})
export class MaterailModule { }

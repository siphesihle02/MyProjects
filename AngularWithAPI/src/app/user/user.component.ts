import { Component, OnInit } from '@angular/core';
import{Iuser} from './user';
import { userService } from './user.service';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'Api-user',
  templateUrl: './user.component.html',
  providers :[userService]
 
})
export class userComponent implements OnInit  {
  pageTitle = 'Current Users';  
  filteredUsers: Iuser[] = [];
  users : Iuser []= [];

  ELEMENT_DATA: Iuser[] = [];
  displayedColumns: string[] = ['id', 'name','username', 'email', 'phone', 'website'];
  dataSource : MatTableDataSource<Iuser> 
  = new MatTableDataSource(this.users)
 
  errorMessage: any;
  private _listFilter: string = '';
get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    console.log('In setter:', value);
    this.filteredUsers = this.performFilter();
  }

  constructor (private userSevice : userService){}
  
    performFilter(): Iuser[] {
      var filterBy = this._listFilter.toLocaleLowerCase();
      return this.users.filter((user: Iuser) =>
        user.username.toLocaleLowerCase().includes(filterBy));
  
    }    
    ngOnInit(): void {
      this.userSevice.getUsers().subscribe({
        next:  users=>{
          console.log(users);
          this.users = users ;
          this.filteredUsers= this.users ;
          this.dataSource=new MatTableDataSource(users);
        },
        error  :err => this.errorMessage = err
             });
        
    }                                                                                                                                                       
}
 
  
  
  
  
  
  



import { Component, OnInit } from '@angular/core';
import{Iuser} from './user';
import { userService } from './user.service';

@Component({
  selector: 'Api-user',
  templateUrl: './user.component.html',
  providers :[userService]
 
})
export class userComponent implements OnInit  {
  pageTitle = 'Current Users';
 
  errorMessage: any;
  private _listFilter: string = '';
get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    console.log('In setter:', value);
    this.filteredUsers = this.performFilter(value);
  }
  filteredUsers: Iuser[] = [];
  users : Iuser []= [];
  constructor (private userSevice : userService){}
  
    performFilter(filterBy: string): Iuser[] {
      filterBy = filterBy.toLocaleLowerCase();
      return this.users.filter((user: Iuser) =>
        user.username.toLocaleLowerCase().includes(filterBy));
    }    
    ngOnInit(): void {
      this.userSevice.getUsers().subscribe({
        next: users=>{
          this.users = users;
          this.filteredUsers= this.users;
        },
        error  :err => this.errorMessage = err
        
        
             })
        ;
    }                                                                                                                                                       
}
 
  
  
  
  
  
  



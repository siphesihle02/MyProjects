import { Component } from '@angular/core';

@Component({
  selector: 'Api-root',
  template: ` 
  <div><h1>{{pageTitle}}</h1> 
  <Api-user></Api-user>
  </div>
  `
})
export class AppComponent {
  title(title: any) {
    throw new Error('Method not implemented.');
  }
  pageTitle = 'Current Users';
}

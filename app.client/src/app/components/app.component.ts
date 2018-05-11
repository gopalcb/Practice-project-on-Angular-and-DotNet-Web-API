import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    template: `
        <h1>{{title}}</h1>
        <nav>
            <a routerLink="/dashboard" routerLinkActive="active">Dashboard</a>
            <a routerLink="/students" routerLinkActive="active">Students</a>
        </nav>
        <br/>
        <router-outlet></router-outlet>
    `,
    styleUrls: ['./styles/app.component.css']
})

export class AppComponent {
    title = 'Student Listing';
}
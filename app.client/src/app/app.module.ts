import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

//import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
//import { InMemoryDataService } from './data/in-memory-data.service';

import { StudentService } from './services/student.service';

import { AppComponent } from './components/app.component';
import { DashboardComponent } from './components/dashboard.component';
import { StudentsComponent } from './components/students.component';
import { StudentDetailComponent } from './components/student-detail.component';

import { AppRoutingModule } from './app-routing.module';


@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    //InMemoryWebApiModule.forRoot(InMemoryDataService),
    AppRoutingModule
  ],
  declarations: [
    AppComponent,
    DashboardComponent,
    StudentsComponent,
    StudentDetailComponent
  ],
  providers: [StudentService],
  bootstrap: [AppComponent]
})
export class AppModule { }

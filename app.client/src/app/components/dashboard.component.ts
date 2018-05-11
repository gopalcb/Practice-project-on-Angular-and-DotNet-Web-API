import { Component, OnInit } from '@angular/core';
import { StudentService } from '../services/student.service';
import { Student } from '../models/student';

@Component({
    selector: 'dashboard',
    templateUrl: './templates/dashboard.component.html',
    styleUrls: ['./styles/dashboard.component.css']
})

export class DashboardComponent implements OnInit {
    students: Student[] = [];

    constructor(private studentService: StudentService) {}

    ngOnInit() {
        this.studentService.getStudents('').then(students => this.students = students.slice(0, 4));
    }
}
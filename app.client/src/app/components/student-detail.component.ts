import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Location } from '@angular/common';
import 'rxjs/add/operator/switchMap';

import { StudentService } from '../services/student.service';

import { Student } from '../models/student';

@Component({
    selector: 'hero-detail',
    templateUrl: './templates/student-detail.component.html',
    styleUrls: ['./styles/student-detail.component.css']
})

export class StudentDetailComponent implements OnInit {
    student: Student;

    constructor(private studentService: StudentService, private route: ActivatedRoute, private location: Location, private router: Router) { }

    ngOnInit() {
        const studentDetail = this;
        this.route.paramMap
            .switchMap((params: ParamMap) => this.studentService.getStudent(params.get('id')))
            .subscribe(student => {
                if (student == null) {
                    student = new Student();
                    student.id = 0;
                    student.name = '';
                    student.email = '';
                }
                studentDetail.student = student;
            });
    }

    goBack(): void {
        this.location.back();
    }

    save(): void {
        debugger
        if (this.student.id === 0) {
            this.studentService.add(this.student)
                .then(response => this.router.navigateByUrl('students'));
        } else {
            this.studentService.update(this.student)
                .then(response => this.goBack());
        }
    }
}

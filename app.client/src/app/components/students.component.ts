import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Student } from '../models/student';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'my-heroes',
  templateUrl: './templates/students.component.html',
  styleUrls: ['./styles/students.component.css']
})

export class StudentsComponent implements OnInit {
  students: Student[];
  selectedStudent: Student;

  constructor(private router: Router, private studentService: StudentService) { }

  ngOnInit(): void {
    this.getStudents();
  }

  getStudents(): void {
    this.studentService.getStudents('').then((students) => this.students = students);
  }

  onSelect(student: Student): void {
    this.selectedStudent = student;
  }

  gotoDetail(): void {
    this.router.navigate(['/student', this.selectedStudent.id]);
  }

  search(keyword: string): void {
    this.studentService.getStudents(keyword).then((students) => this.students = students);
  }

  edit(student: Student): void {
    debugger
    this.router.navigate(['/student', student.id]);
  }

  delete(student: Student): void {
    var result = confirm("Are you sure you want to delete?");
    if (result) {
      this.studentService.delete(student)
      .then(() => {
        debugger
        this.studentService.getStudents('').then((students) => this.students = students);
      });
    }
  }
}

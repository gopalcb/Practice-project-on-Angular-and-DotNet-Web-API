import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import 'rxjs/add/operator/toPromise';

import { Student } from '../models/student';

@Injectable()
export class StudentService {
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private studentsUrl = '//localhost:23456/api/student';

    constructor(private http: Http) { 
        // this.http = http;
        // this.headers = new Headers();
        // this.headers.append('Content-Type', 'application/json');
    }

    handleError(error: any): Promise<any> {
        console.error(`An error occured`, error);
        return Promise.reject(error.message || error);
    }

    getStudents(keyword: string): Promise<Student[]> {
        var url = `${this.studentsUrl}/get-students?keyword=${keyword}`;
        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as Student[])
            .catch(this.handleError);
    }

    getStudent(id: string): Promise<Student> {
        debugger
        const url = `${this.studentsUrl}/get-student/${id}`;
        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as Student)
            .catch(this.handleError);
    }

    add(student: Student): Promise<any> {
        const url = `${this.studentsUrl}/save-student`;
        return this.http.post(url, JSON.stringify(student), { headers: this.headers })
            .toPromise()
            .then(response => response.json())
            .catch(this.handleError);
    }

    update(student: Student): Promise<Student> {
        const url = `${this.studentsUrl}/update-student`;
        return this.http.post(url, JSON.stringify(student), { headers: this.headers })
            .toPromise()
            .then(() => student)
            .catch(this.handleError);
    }

    delete(student: Student): Promise<Student> {
        const url = `${this.studentsUrl}/delete-student/${student.id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then((response) => response.json())
            .catch(this.handleError);
    }
}

import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'add-car',
  standalone: true,
  templateUrl: './add-car-page.component.html',
  styleUrls: ['./add-car-page.component.css'],
  imports: [ReactiveFormsModule, FormsModule, CommonModule]
})
export class AddCarPageComponent implements OnInit {
  addCarForm: FormGroup = this.fb.group({});


  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.addCarForm = this.fb.group({
      carName: ['', Validators.required],
      model: ['', Validators.required],
      color: ['', Validators.required],
      releaseDate: ['', [Validators.required, Validators.min(1900), Validators.max(new Date().getFullYear())]],
      price: ['', [Validators.required, Validators.min(0)]],
      vinNumber: ['', [Validators.required, Validators.minLength(17), Validators.maxLength(17)]]
    });
  }

  // Перехід на сторінку адміністратора
  goToAdminPage(): void {
    this.router.navigate(['/admin']);
  }

  // Відправляємо форму і додаємо автомобіль
  onSubmit(): void {
    if (this.addCarForm.valid) {
      const carData = this.addCarForm.value;
      this.http.post('https://localhost:7137/api/Admin/addcar', carData)
      .subscribe({
        next: (response) => {
          console.log('Автомобіль додано:', response);
          this.router.navigate(['/admin']);
          this.addCarForm.reset();
        },
        error: (error) => {
          console.error('Помилка при додаванні автомобіля:', error);
        }
      });
    }
  }

  goToAdmin() {
    this.router.navigate(['/admin']);
  }
}

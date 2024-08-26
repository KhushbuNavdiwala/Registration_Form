import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { CompanyService } from '../services/company.service';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { HttpClientModule } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';

@Component({
 selector: 'app-company-form',
 standalone: true,
  templateUrl: './company-form.component.html',
  styleUrls: ['./company-form.component.css'],
  imports:[
    CommonModule, 
    ReactiveFormsModule,
    MatInputModule, 
    MatSelectModule,
    MatButtonModule,
    MatFormFieldModule,
    HttpClientModule,
    MatIconModule,
    MatCheckboxModule,
   
   
  ]
})
export class CompanyFormComponent implements OnInit {


  companyForm!: FormGroup;
    hide: any;
    

  constructor(private fb: FormBuilder, private companyService: CompanyService) {}

  ngOnInit(): void {
    this.companyForm = this.fb.group({

      companyName: ['', Validators.required],
      industry: ['', Validators.required],
      firstName : ['',[Validators.required,
        Validators.minLength(2),
        Validators.pattern("[a-zA-Z].*")]],

      lastName : ['',[Validators.required,
       Validators.minLength(2),
       Validators.pattern("[a-zA-Z].*")]],

      userName : ['',[Validators.required,Validators.minLength(2)]],
      password : ['',[Validators.required, Validators.minLength(6)]],
      confirmPassword : ['',[Validators.required, this.confirmPasswordValidator('password')]],
      email : ['',[Validators.pattern("^[a-zA-Z0-9_.±]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$")]],
      termsAndConditions: [false, Validators.requiredTrue], // Checkbox for terms and conditions
      privacyPolicy: [false, Validators.requiredTrue], // Checkbox for privacy policy
    });
  }

  confirmPasswordValidator(passwordField: string): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const password = control.parent?.get(passwordField)?.value;
      const confirmPassword = control.value;
  
      if (password !== confirmPassword) {
        return { passwordMismatch: true };
      }
      return null;
    };
  }



  onSubmit() {
    if (this.companyForm.valid) {

      const { termsAndConditions, privacyPolicy,...formData } = this.companyForm.value; 
      //exclude data 

      this.companyService.addCompany(this.companyForm.value).subscribe(
        response => {
          console.log('Data',this.companyForm.value);
          console.log('Company added successfully', response);
        },
        error => {
          console.error('not successful', error);
        }
      );
    }
  }
}

import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CompanyFormComponent } from './company-form/company-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
    CompanyFormComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'CompanyRegistrationApp';
}

import { Component } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { AdminSignInDTORequest, AuthService } from '../../services/auth-service.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  email = new FormControl('');
  password = new FormControl('');
  /**
   *
   */
  constructor(private readonly _authService: AuthService) {

  }
  signIn() {
    let email = this.email.value ?? '';
    let password = this.password.value ?? '';
    const request: AdminSignInDTORequest = {
      email: email,
      password: password
    }
    this._authService.signIn(request).subscribe((response) => {
      console.log(response);
    });
  }
}

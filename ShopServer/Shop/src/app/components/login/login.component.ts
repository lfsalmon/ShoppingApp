import { Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Customer } from 'src/app/models/customer';
import { Roles } from 'src/app/models/MenuItems';
import { Shop } from 'src/app/models/shop';
import { UserSiginup } from 'src/app/models/UserSiginup';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'] 
})
export class LoginComponent implements OnInit {
  public regsiterForm:FormGroup;
  public loginForm: FormGroup;
  public isCustomer:boolean=true;
  userRoles = Object.values([Roles.Customer,Roles.Store]).filter(value => typeof value === 'number'); 
  hide = true;  
  hide_siginup = true;  
  @ViewChild('container', { static: true }) container!: ElementRef;

  constructor(private fb: FormBuilder,
    private cookies:CookieService,
    private router:Router,
    private renderer: Renderer2,
    private _userService:UserService,
    private snackBar: MatSnackBar
  ) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });

    this.regsiterForm = this.fb.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required]],
      name: ['', [Validators.required]],
      role: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      lastname:['',Validators.nullValidator]
    });

    this.regsiterForm.get('role')?.valueChanges.subscribe(value => {
      this.isCustomer=(value===Roles.Customer);
      console.log('Selected Role:', this.isCustomer);
    });


  }
  getRoleName(role: Roles): string {
    return Roles[role];
  }

  ngAfterViewInit() {
  
  }
  onLoginSubmit() {
    if (this.loginForm.valid) {
      let Userrequest=new UserSiginup();
      const loginData = this.loginForm.value;
      Userrequest.Username=loginData.username;
      Userrequest.Password=loginData.password; 
      this._userService.Login(Userrequest).subscribe(
        updateuser => {
          this.snackBar.open('El usuario inicio sesion correctamente', 'x', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass: ['custom-snackbar']
          });
        
          
          localStorage.setItem('user', JSON.stringify(updateuser));
          if(updateuser.role.toString()===Roles.Store.toString()){
            this.router.navigate(['/store-home']);
          }else if(updateuser.role==Roles.Customer){
           
            this.router.navigate(['/all-item-list']);
          }
          
          this.loginForm.reset();
        },
        error => {
          this.snackBar.open('Error ', 'x', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass: ['custom-snackbar']
          });
        }
      );
    }
  }
  onSigupSubmit() {
    if (this.regsiterForm.valid) {
      let Userrequest=new UserSiginup();
      const registerData = this.regsiterForm.value;
      Userrequest.Username=registerData.username;
      Userrequest.Email=registerData.email;
      Userrequest.Password=registerData.password;
      Userrequest.Role=registerData.role;
      if(Userrequest.Role==Roles.Customer){
        Userrequest.Customer=new Customer();
        Userrequest.Customer.name=registerData.name;
        Userrequest.Customer.lastName=registerData.lastname;
      }
      else  if(Userrequest.Role==Roles.Store){
        Userrequest.Store= new Shop();
        Userrequest.Store.name=registerData.name;
      }
      console.log('Register Form Submitted!', Userrequest);
      this._userService.Siginup(Userrequest).subscribe(
        updateuser => {
          this.snackBar.open('El usuario fue agregado correctamente', 'x', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass: ['custom-snackbar']
          });
          
          this.regsiterForm.reset();
        },
        error => {
          this.snackBar.open('Error ', 'x', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass: ['custom-snackbar']
          });
        }
      );
    }
  }
  
  


  OnSigniupClick()
  {
  
    this.renderer.addClass(this.container.nativeElement, 'right-panel-active');
  }
  OnLoginClick(){
    this.renderer.removeClass(this.container.nativeElement, 'right-panel-active');
  }

  ngOnInit(): void {
  }

}

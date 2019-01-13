/*
@Component({
  selector: 'app-hospital-edit',
  templateUrl: './hospital-edit.component.html',
  styleUrls: ['./hospital-edit.component.css']
}){
 @Input() hospitalData:any = { hospital_name: '', hospital_desc: ''};

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.rest.getHospital(this.route.snapshot.params['id']).subscribe((data: {}) => {
      console.log(data);
      this.hospitalData = data;
    });
  }

  updateProduct() {
    this.rest.updateHospital(this.route.snapshot.params['id'], this.hospitalData).subscribe((result) => {
      this.router.navigate(['/hospital-details/'+result._id]);
    }, (err) => {
      console.log(err);
    });
  }

}
*/

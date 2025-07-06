import { Component } from '@angular/core';
import { Job } from '../../models/job.model';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { JobService } from '../../services/job.service';

@Component({
  selector: 'app-edit-job',
  imports: [FormsModule],
  templateUrl: './edit-job.component.html',
  styleUrl: './edit-job.component.css'
})
export class EditJobComponent {
  job: Job= {
    id: 0,
    title: "",
    description: "",
    company: "",
    location: "",
    postedDate: new Date()
  };

  constructor(
    public router: Router,
    private route: ActivatedRoute,
    private jobService: JobService
  ){}

  ngOnInit(): void{
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!isNaN(id)) {
      this.getJob(id); 
    } else {
      console.error('Invalid job ID');
    }
  }

  getJob(id: number): void{
    this.jobService.getJob(id).subscribe({
      next: (data) => {
        this.job = data;
      },
      error: (e) => console.error(e)
    });
  }

  updateJob(): void {
    this.jobService.updateJob(this.job).subscribe({
      next: () => {
        if (this.job.id !== undefined) {
          this.router.navigate(['/jobs', this.job.id]); 
        } else {
          console.error('Job ID is undefined. Cannot navigate.');
        }
      },
      error: (e) => console.error(e)
    });
  }
}

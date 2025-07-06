import { Component } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Job } from '../../models/job.model';
import { Router } from '@angular/router';
import { JobService } from '../../services/job.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-job-details',
  imports: [RouterModule, CommonModule],
  templateUrl: './job-details.component.html',
  styleUrl: './job-details.component.css'
})
export class JobDetailsComponent {

  job: Job | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private jobService: JobService
  ){}

  ngOnInit(): void {
    this.getJob();
  }

  getJob(): void{
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.jobService.getJob(id).subscribe({
      next: (data) => {
        this.job = data;
      },
      error: (e) => console.error(e)
    });
  }
 
  deleteJob(): void {
    if (confirm("Are you sure you want to delete this job?")) {
      if (this.job && this.job.id !== undefined) {
        this.jobService.deleteJob(this.job.id).subscribe({
          next: () => {
            this.router.navigate(['/jobs']);
          },
          error: (e) => console.error(e)
        });
      } else {
        console.error('Job ID is undefined. Cannot delete job.');
      }
    }
  }

}

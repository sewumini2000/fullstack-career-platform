import { Routes } from '@angular/router';
import { JobListComponent } from './components/job-list/job-list.component';
import { AddJobComponent } from './components/add-job/add-job.component';
import { JobDetailsComponent } from './components/job-details/job-details.component';
import { EditJobComponent } from './components/edit-job/edit-job.component';

export const routes: Routes = [
    {path:'', redirectTo:'/jobs', pathMatch:'full'},
    {path:'jobs', component:JobListComponent},
    {path:'jobs/add', component:AddJobComponent},
    {path:'jobs/:id', component:JobDetailsComponent},
    {path:'jobs/:id/edit', component:EditJobComponent}
];

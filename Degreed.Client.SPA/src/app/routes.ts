import { ContentComponent } from './content/content.component';

export const appRoutes = [
  { path: 'jokes', component: ContentComponent },
  { path: '', redirectTo: '/jokes', pathMatch: 'full'}
]

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testkamna.Database;
using testkamna.Models;


namespace testkamna.Services
{
    public class LeadsService
    {
        private readonly TestKamnaContext _leads;

        public LeadsService(TestKamnaContext lc)
        {
            _leads = lc;
        }

        public async Task<LeadsViewModel> GetAllData(LeadsViewModel model)
        {

            var data = await _leads.Leads.ToListAsync();

            if (data != null)
            {
                var result = new List<LeadsViewModel>();
                foreach (var item in data)
                {
                    var res = new LeadsViewModel()
                    {
                        ContactName = item.ContactName,
                        Address = item.Address,
                        Phone = item.Phone,
                        CompanyName = item.CompanyName,
                        Interest = item.Interest,
                        Email = item.Email,
                        Remark = item.Remark,
                        LeadId = item.LeadId,

                    };

                    result.Add(res);
                }
                model.List = result;
            }
            return model;

        }

        public async Task<LeadsViewModel> GetSearchData(string searchString)
        {
            var data = await _leads.Leads.ToListAsync();

            if (data != null)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    var res = data.Where(item => item.ContactName.ToLower().Contains(searchString.ToLower())
                                  || item.Address.ToLower().Contains(searchString.ToLower())
                                  || item.Phone.ToLower().Contains(searchString.ToLower())
                                  || item.CompanyName.ToLower().Contains(searchString.ToLower())
                                  || item.Interest.ToLower().Contains(searchString.ToLower())
                                  || item.Email.ToLower().Contains(searchString.ToLower())).ToList();

          
                }
                var leadsViewModel = new LeadsViewModel
                {
                    List = data.Select(item => new LeadsViewModel
                    {
                        ContactName = item.ContactName,
                        Address = item.Address,
                        Phone = item.Phone,
                        CompanyName = item.CompanyName,
                        Interest = item.Interest,
                        Email = item.Email,
                        Remark = item.Remark,
                        LeadId = item.LeadId,
                    }).ToList()
                };

                return leadsViewModel;

            }
            return null;

        }


        public async Task<LeadsViewModel> AddLead(LeadsViewModel model)
        {
            model.ResponseStatus = false;
            if (model.LeadId > 0)
            {
                var res = await _leads.Leads.FindAsync(model.LeadId);
                if (res != null)
                {
                    res.LeadId = model.LeadId;
                    res.ContactName = model.ContactName;
                    res.Address = model.Address;
                    res.Phone = model.Phone;
                    res.CompanyName = model.CompanyName;
                    res.Interest = model.Interest;
                    res.Location = model.Location;
                    res.Flag = model.Flag;
                    res.Email = model.Email; 
                    res.Remark = model.Remark;

                    _leads.Leads.Update(res);

                    await _leads.SaveChangesAsync();
                    model.ResponseStatus = true;
                }

            }

            else
            {
                var newLead = new Lead()
                {
                    LeadId = model.LeadId,
                    ContactName = model.ContactName,
                    Address = model.Address,
                    Phone = model.Phone,
                    CompanyName = model.CompanyName,
                    Interest = model.Interest,
                    Location = model.Location,
                    Flag = model.Flag,
                    Email = model.Email,
                    Remark = model.Remark,
                };
                await _leads.Leads.AddAsync(newLead);
                await _leads.SaveChangesAsync();
                model.ResponseStatus = true;
            }
            return model;
        }

        public async Task<LeadsViewModel> LeadDetail(LeadsViewModel model)
        {
            var res = await _leads.Leads.FirstOrDefaultAsync(x => x.LeadId == model.LeadId);
            if (res != null)
            {
                model.LeadId = res.LeadId;
                model.ContactName = res.ContactName;
                model.Address = res.Address;
                model.Phone = res.Phone;
                model.CompanyName = res.CompanyName;
                model.Interest = res.Interest;
                model.Location = res.Location;
                model.Flag = res.Flag;
                model.Email = res.Email;
                model.Remark = res.Remark;
                model.FollowUpData = await GetAllFollowUps(new FollowUpsViewModel()
                {
                    LeadId = model.LeadId
                });
                model.FollowUpData.LeadId = res.LeadId;
               model.CommentData = await GetAllComments(new CommentsViewModel()
                     {
                         LeadId = model.LeadId
                     });
                model.CommentData.LeadId = res.LeadId;
            }

            return model;
        }

        public async Task<LeadsViewModel>Delete(LeadsViewModel model)
        {
            var res = await _leads.Leads.FirstOrDefaultAsync(x => x.LeadId == model.LeadId);
            model.ResponseStatus = false;
            if (res != null)
            {
                _leads.Leads.Remove(res);
                await _leads.SaveChangesAsync();
                model.ResponseStatus = true;
            }

            return model;
        }

        public async Task<FollowUpsViewModel> GetAllFollowUps (FollowUpsViewModel model)
        {
            var followups = await _leads.FollowUps.Where(x => x.LeadId == model.LeadId).ToListAsync();
            if(followups != null)
            {
                foreach (var item in followups)
                {
                    model.List.Add(new FollowUpsViewModel()
                    {
                        FollowUpId = item.FollowUpId,
                        LeadId = item.LeadId,
                        FollowUpDate = item.FollowUpDate,
                        CreatedDate = DateTime.Now,
                        Notes = item.Notes,
                    });
                }
            }
      
            return model;
        }

        public async Task<CommentsViewModel> GetAllComments (CommentsViewModel model)
        {
            var comment = await _leads.Comments.Where(x => x.LeadId == model.LeadId).ToListAsync();
            if(comment!=null)
            {
                foreach (var item in comment)
                {
                    model.List.Add(new CommentsViewModel()
                    {
                        CommentId = item.CommentId,
                        LeadId = item.LeadId,
                        CommentText = item.CommentText,
                        CommentDate = DateTime.Now,
                    });
                }
            }

            return model;
        }

        public async Task<FollowUpsViewModel> AddFollowUps (FollowUpsViewModel model)
        {
             model.ResponseStatus = false;
            var data = new FollowUp
            {
                FollowUpId = model.FollowUpId,
                LeadId = model.LeadId,
                CreatedDate = DateTime.Now,
                Notes = model.Notes,
                FollowUpDate = model.FollowUpDate    
            };
            await _leads.FollowUps.AddAsync(data);
            await _leads.SaveChangesAsync();
            model.ResponseStatus = true;
            return model;
        }

        public async Task<CommentsViewModel> AddComments (CommentsViewModel model)
        {
            model.ResponseStatus = false;
            var data = new Comment
            {
                CommentId = model.CommentId,
                LeadId = model.LeadId,
                CommentText = model.CommentText,
                CommentDate = DateTime.Now,
            };
            await _leads.Comments.AddAsync(data);
            await _leads.SaveChangesAsync();
            model.ResponseStatus = true;
            return model;
        }

    }
}

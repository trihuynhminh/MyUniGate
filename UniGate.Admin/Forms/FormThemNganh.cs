using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniGate.Admin.Services;
using UniGate.Shared.DTOs;

namespace UniGate.Admin.Forms
{
    public partial class FormThemNganh : Form
    {
        private readonly int _universityId;
        private readonly MajorAdminDto? _edit;

        private readonly MajorService _majorService = new();
        private readonly SubjectGroupService _groupService = new();
        private readonly AdmissionService _admissionService = new();

        public FormThemNganh()
        {
            InitializeComponent();
            this.Load += FormThemNganh_Load;
        }

        public FormThemNganh(int universityId) : this()
        {
            _universityId = universityId;
            
        }

        
        public FormThemNganh(int universityId, MajorAdminDto edit) : this(universityId)
        {
            _edit = edit;
            
        }

        private async void FormThemNganh_Load(object sender, EventArgs e)
        {
            var groups = await _groupService.GetAllAsync();

            checkedListBox1_ToHop.DataSource = groups;
            checkedListBox1_ToHop.DisplayMember = "GroupName";
            checkedListBox1_ToHop.ValueMember = "GroupID";

            if (_edit != null)
            {
                txtMajorCode.Text = _edit.MajorCode;
                txtMajorName.Text = _edit.Name;
                richtextbox_descriptionnganh.Text = _edit.Description;
                txtMinScore.Text = _edit.CutoffScore.ToString();
                txtYear.Text = _edit.Year.ToString();

                // tick tổ hợp
                for (int i = 0; i < checkedListBox1_ToHop.Items.Count; i++)
                {
                    var g = (SubjectGroupDto)checkedListBox1_ToHop.Items[i];
                    if (_edit.Combos.Contains(g.GroupName))
                        checkedListBox1_ToHop.SetItemChecked(i, true);
                }
            }
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMinScore.Text, out var score) ||
        !short.TryParse(txtYear.Text, out var year))
            {
                MessageBox.Show("Điểm hoặc năm không hợp lệ");
                return;
            }

            var groupIds = checkedListBox1_ToHop.CheckedItems
                .Cast<SubjectGroupDto>()
                .Select(x => x.GroupID)
                .ToList();

            if (!groupIds.Any())
            {
                MessageBox.Show("Phải chọn ít nhất 1 tổ hợp");
                return;
            }

            var dto = new MajorUpsertDto
            {
                MajorCode = txtMajorCode.Text.Trim(),
                Name = txtMajorName.Text.Trim(),
                Description = richtextbox_descriptionnganh.Text,
                UniversityID = _universityId,
                Year = year,
                MinScore = score,
                GroupIds = groupIds
            };

            if (_edit == null)
            {
                try
                {
                    var createdId = await _majorService.CreateAsync(dto);
                    dto.Id = createdId;
                    await _majorService.UpdateAsync(createdId, dto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm ngành: " + ex.Message);
                    return;
                }
            }
            else
            {
                
                dto.Id = _edit.Id;
                await _majorService.UpdateAsync(_edit.Id, dto);
            }
           

            DialogResult = DialogResult.OK;
        }


    }
}

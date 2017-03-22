using System;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class RelationshipDTO
    {
        [Required]
        public Guid RelationshipId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(50)]
        public string CollectionName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(50)]
        public string CollectionFriendlyName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(50)]
        public string ParentName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(50)]
        public string ParentFriendlyName { get; set; }

        [Required]
        public Guid ParentEntityId { get; set; }

        [Required]
        public Guid ChildEntityId { get; set; }

        [Required]
        public Guid ParentFieldId { get; set; }

        [Required]
        public bool DisplayListOnParent { get; set; }

        [Required]
        public bool Hierarchy { get; set; }

        [Required]
        public int SortOrder { get; set; }

        [Required]
        public RelationshipAncestorLimits RelationshipAncestorLimit { get; set; }

        public EntityDTO ChildEntity { get; set; }

        public EntityDTO ParentEntity { get; set; }

        public FieldDTO ParentField { get; set; }

    }

    public partial class ModelFactory
    {
        public RelationshipDTO Create(Relationship relationship)
        {
            var relationshipDTO = new RelationshipDTO();

            relationshipDTO.RelationshipId = relationship.RelationshipId;
            relationshipDTO.CollectionName = relationship.CollectionName;
            relationshipDTO.CollectionFriendlyName = relationship.CollectionFriendlyName;
            relationshipDTO.ParentName = relationship.ParentName;
            relationshipDTO.ParentFriendlyName = relationship.ParentFriendlyName;
            relationshipDTO.ParentEntityId = relationship.ParentEntityId;
            relationshipDTO.ChildEntityId = relationship.ChildEntityId;
            relationshipDTO.ParentFieldId = relationship.ParentFieldId;
            relationshipDTO.DisplayListOnParent = relationship.DisplayListOnParent;
            relationshipDTO.Hierarchy = relationship.Hierarchy;
            relationshipDTO.SortOrder = relationship.SortOrder;
            relationshipDTO.RelationshipAncestorLimit = relationship.RelationshipAncestorLimit;
            relationshipDTO.ParentField = relationship.ParentField == null ? null : Create(relationship.ParentField);
            relationshipDTO.ChildEntity = relationship.ChildEntity == null ? null : Create(relationship.ChildEntity);
            relationshipDTO.ParentEntity = relationship.ParentEntity == null ? null : Create(relationship.ParentEntity);

            return relationshipDTO;
        }

        public void Hydrate(Relationship relationship, RelationshipDTO relationshipDTO)
        {
            relationship.CollectionName = relationshipDTO.CollectionName;
            relationship.CollectionFriendlyName = relationshipDTO.CollectionFriendlyName;
            relationship.ParentName = relationshipDTO.ParentName;
            relationship.ParentFriendlyName = relationshipDTO.ParentFriendlyName;
            relationship.ParentEntityId = relationshipDTO.ParentEntityId;
            relationship.ChildEntityId = relationshipDTO.ChildEntityId;
            relationship.ParentFieldId = relationshipDTO.ParentFieldId;
            relationship.DisplayListOnParent = relationshipDTO.DisplayListOnParent;
            relationship.Hierarchy = relationshipDTO.Hierarchy;
            relationship.SortOrder = relationshipDTO.SortOrder;
            relationship.RelationshipAncestorLimit = relationshipDTO.RelationshipAncestorLimit;
        }
    }
}
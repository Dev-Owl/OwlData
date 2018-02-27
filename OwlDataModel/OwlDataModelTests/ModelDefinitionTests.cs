using OwlDataModel;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using ValidationFunctions;

namespace OwlDataModelTests
{
    public class ModelDefinitionTests
    {
        [Fact]
        public void LoadEmptyPropertyList()
        {
            ModelDefinition newModel = new ModelDefinition();
            Assert.Empty(newModel.Properties);
            newModel.CreateModelPropertyList(new List<OwlDataModel.DTO.ModelPropertyDTO>());
            Assert.Empty(newModel.Properties);
        }

        [Fact]
        public void LoadPropertyList()
        {
            ModelDefinition newModel = new ModelDefinition();
            newModel.CreateModelPropertyList(new List<OwlDataModel.DTO.ModelPropertyDTO>() {
                new OwlDataModel.DTO.ModelPropertyDTO()
                {
                    Name="Name",
                    Required=true,
                    Type = PropertyType.String
                }
            });
            Assert.NotEmpty(newModel.Properties);
            var property = newModel.Properties.FirstOrDefault();
            Assert.NotNull(property);
            Assert.NotNull(property.ValidationFunctions);
        }

        [Fact]
        public void LoadAnyValidationFunction()
        {
            ModelDefinition newModel = new ModelDefinition();
            newModel.CreateModelPropertyList(new List<OwlDataModel.DTO.ModelPropertyDTO>() {
                new OwlDataModel.DTO.ModelPropertyDTO()
                {
                    Name="Name",
                    Required=true,
                    Type = PropertyType.String,
                    ValidationFunctions = new List<ValidationFunction>()
                    {
                        new ValidationFunction()
                        {
                            FunctionName ="MinLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",5 } },
                            Score = 1F
                        },
                        new ValidationFunction()
                        {
                            FunctionName ="MaxLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",10 } },
                            Score = 1F
                        }
                    }
                }
            });
            Assert.NotEmpty(newModel.Properties);
            var property = newModel.Properties.FirstOrDefault();
            Assert.NotNull(property);
            Assert.NotEmpty(property.ValidationFunctions);
        }

        [Fact]
        public void LoadEntityToDefinition()
        {
            ModelDefinition newModel = new ModelDefinition();
            newModel.ResetScoreAndLoadNewEntity(new Dictionary<string, object>() { { "Name", "Hans Wurst" }, { "SureName", null } });
            Assert.NotNull(newModel.Entity);
        }

        [Fact]
        public void CheckRequiredFiledHaveValue()
        {
            ModelDefinition newModel = new ModelDefinition();
            newModel.CreateModelPropertyList(new List<OwlDataModel.DTO.ModelPropertyDTO>() {
                new OwlDataModel.DTO.ModelPropertyDTO()
                {
                    Name="Name",
                    Required=true,
                    Type = PropertyType.String,
                    ValidationFunctions = new List<ValidationFunction>()
                    {
                        new ValidationFunction()
                        {
                            FunctionName ="MinLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",5 } },
                            Score = 1F
                        },
                        new ValidationFunction()
                        {
                            FunctionName ="MaxLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",15 } },
                            Score = 1F
                        }
                    }
                },
                new OwlDataModel.DTO.ModelPropertyDTO()
                {
                    Name="SureName",
                    Required=false,
                    Type = PropertyType.String,
                    ValidationFunctions = new List<ValidationFunction>()
                    {
                        new ValidationFunction()
                        {
                            FunctionName ="MinLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",5 } },
                            Score = 1F
                        },
                        new ValidationFunction()
                        {
                            FunctionName ="MaxLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",15 } },
                            Score = 1F
                        }
                    }
                }
            });
            Assert.NotEmpty(newModel.Properties);
            var property = newModel.Properties.FirstOrDefault();
            Assert.NotNull(property);
            Assert.NotEmpty(property.ValidationFunctions);
            newModel.ResetScoreAndLoadNewEntity(new Dictionary<string, object>() { { "Name", "Hans Dieter" }, { "SureName", null } });
            Assert.NotNull(newModel.Entity);
            Assert.True(newModel.Properties.CheckAllRequiredPropertiesExists());
            newModel.ResetScoreAndLoadNewEntity(new Dictionary<string, object>() { { "Name", null }, { "SureName", null } });
            Assert.False(newModel.Properties.CheckAllRequiredPropertiesExists());
        }

        [Fact]
        public void RunBuildInMinMaxLengthFunctions()
        {
            ModelDefinition newModel = new ModelDefinition();
            newModel.CreateModelPropertyList(new List<OwlDataModel.DTO.ModelPropertyDTO>() {
                new OwlDataModel.DTO.ModelPropertyDTO()
                {
                    Name="Name",
                    Required=true,
                    Type = PropertyType.String,
                    ValidationFunctions = new List<ValidationFunction>()
                    {
                        new ValidationFunction()
                        {
                            FunctionName ="MinLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",5 } },
                            Score = 1F
                        },
                        new ValidationFunction()
                        {
                            FunctionName ="MaxLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",15 } },
                            Score = 1F
                        }
                    }
                },
                new OwlDataModel.DTO.ModelPropertyDTO()
                {
                    Name="SureName",
                    Required=false,
                    Type = PropertyType.String,
                    ValidationFunctions = new List<ValidationFunction>()
                    {
                        new ValidationFunction()
                        {
                            FunctionName ="MinLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",5 } },
                            Score = 1F
                        },
                        new ValidationFunction()
                        {
                            FunctionName ="MaxLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",15 } },
                            Score = 1F
                        }
                    }
                }
            });
            Assert.NotEmpty(newModel.Properties);
            var property = newModel.Properties.FirstOrDefault();
            Assert.NotNull(property);
            Assert.NotEmpty(property.ValidationFunctions);
            newModel.ResetScoreAndLoadNewEntity(new Dictionary<string, object>() { { "Name", "Hans Dieter" }, { "SureName", null } });
            Assert.NotNull(newModel.Entity);
            Assert.True(newModel.Properties.CheckAllRequiredPropertiesExists());
            newModel.Properties.GenerateScoreForProperties();
            Assert.Equal(1F, newModel.Properties[0].Score);
            Assert.Equal(0.5F, newModel.Properties[1].Score);
            Assert.Equal(0.75F, newModel.Properties.CalculateTotalScore());
        }

        [Fact]
        public void GetNoneNullValidationManager()
        {
            Assert.NotNull(ValidationManager.GetActiveValidationManager());
        }

        [Fact]
        public void ValidationManagerContainsBuildInFunctions()
        {
            var validationManager = ValidationManager.GetActiveValidationManager();
            Assert.True(validationManager.KnownFunctions.Any());
        }

        [Fact]
        public void CheckValidationForMissingPropertyInEntity()
        {
            ModelDefinition newModel = new ModelDefinition();
            newModel.CreateModelPropertyList(new List<OwlDataModel.DTO.ModelPropertyDTO>() {
                new OwlDataModel.DTO.ModelPropertyDTO()
                {
                    Name="Name",
                    Required=true,
                    Type = PropertyType.String,
                    ValidationFunctions = new List<ValidationFunction>()
                    {
                        new ValidationFunction()
                        {
                            FunctionName ="MinLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",5 } },
                            Score = 1F
                        },
                        new ValidationFunction()
                        {
                            FunctionName ="MaxLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",15 } },
                            Score = 1F
                        }
                    }
                },
                new OwlDataModel.DTO.ModelPropertyDTO()
                {
                    Name="LastName",
                    Required=false,
                    Type = PropertyType.String,
                    ValidationFunctions = new List<ValidationFunction>()
                    {
                        new ValidationFunction()
                        {
                            FunctionName ="MinLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",5 } },
                            Score = 1F
                        },
                        new ValidationFunction()
                        {
                            FunctionName ="MaxLength",
                            OptionalParameter = new Dictionary<string, object>(){ {"length",15 } },
                            Score = 1F
                        }
                    }
                }
            });
            Assert.NotEmpty(newModel.Properties);
            var property = newModel.Properties.FirstOrDefault();
            Assert.NotNull(property);
            Assert.NotEmpty(property.ValidationFunctions);
            newModel.ResetScoreAndLoadNewEntity(new Dictionary<string, object>() { { "Name", "Hans Dieter" }, { "SureName", null } });
            Assert.NotNull(newModel.Entity);
            Assert.True(newModel.Properties.CheckAllRequiredPropertiesExists());
            newModel.Properties.GenerateScoreForProperties();
            Assert.Equal(1F, newModel.Properties[0].Score);
            Assert.Equal(0F, newModel.Properties[1].Score);
            Assert.Equal(0.5F, newModel.Properties.CalculateTotalScore());
        }
    }
}

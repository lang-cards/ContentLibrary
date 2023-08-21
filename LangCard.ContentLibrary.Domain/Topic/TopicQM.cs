using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangCard.ContentLibrary.Domain.Topic;

public record TopicQM(
    int id,
    string name,
    string description,
    int order,
    DateTimeOffset createdAt,
    string createdBy);

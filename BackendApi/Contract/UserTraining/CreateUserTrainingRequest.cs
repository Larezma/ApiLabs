﻿namespace BackendApi.Contract.UserTraining
{
    public class CreateUserTrainingRequest
    {
        public int TrainingId { get; set; }

        public int? TrainerId { get; set; }

        public string DayOfWeek { get; set; } = null!;

        public DateTime? StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        public string Duration { get; set; } = null!;

        public string? Notes { get; set; }

        public string TrainingStatus { get; set; } = null!;
    }
}
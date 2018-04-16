using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace UnitTests
{
    public class TirePressureTests
    {
		[Test]
		public void SensorPopNextPressureValueValid()
		{
			Sensor sensor = new Sensor();
			double nextDoubleReturnValue = 0.5;

			Mock<Random> randomMock = new Mock<Random>();
			randomMock.Setup(m => m.NextDouble()).Returns(nextDoubleReturnValue);
			FieldInfo randomInfo = typeof(Sensor).GetField("_randomPressureSampleSimulator", BindingFlags.NonPublic | BindingFlags.Instance);
			randomInfo.SetValue(sensor, randomMock.Object);

			double result = sensor.PopNextPressurePsiValue();

			Assert.That(result, Is.EqualTo(17.5));
		}

		[Test]
		public void TestTurnAlarmOn()
		{
			Alarm alarm = new Alarm();
			double nextDoubleReturnValue = 0.1;

			Mock<Sensor> sensorMock = new Mock<Sensor>();
			FieldInfo sensorInfo = typeof(Alarm).GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
			sensorInfo.SetValue(alarm, sensorMock.Object);

			Mock<Random> randomMock = new Mock<Random>();
			randomMock.Setup(m => m.NextDouble()).Returns(nextDoubleReturnValue);
			FieldInfo randomInfo = typeof(Sensor).GetField("_randomPressureSampleSimulator", BindingFlags.NonPublic | BindingFlags.Instance);
			randomInfo.SetValue(sensorMock.Object, randomMock.Object);

			alarm.Check();
			bool alarmState = alarm.AlarmOn;

			Assert.That(alarmState == true);
		}

		[Test]
		public void TestTurnAlarmOff()
		{
			Alarm alarm = new Alarm();
			double nextDoubleReturnValue = 0.6;

			Mock<Sensor> sensorMock = new Mock<Sensor>();
			FieldInfo sensorInfo = typeof(Alarm).GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
			sensorInfo.SetValue(alarm, sensorMock.Object);

			Mock<Random> randomMock = new Mock<Random>();
			randomMock.Setup(m => m.NextDouble()).Returns(nextDoubleReturnValue);
			FieldInfo randomInfo = typeof(Sensor).GetField("_randomPressureSampleSimulator", BindingFlags.NonPublic | BindingFlags.Instance);
			randomInfo.SetValue(sensorMock.Object, randomMock.Object);

			alarm.Check();
			bool alarmState = alarm.AlarmOn;

			Assert.That(alarmState == false);
		}
    }
}

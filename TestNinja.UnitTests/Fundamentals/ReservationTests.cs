using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class ReservationTests
    {
        private Reservation _reservation;
        private User _user;
        [SetUp]
        public void SetUp()
        {
            _reservation = new Reservation();
            _user = new User();
        }

        [Test]
        public void CanBeCancelledBy_SameUser_ReturnTrue()
        {
            _reservation.MadeBy = _user;

            Assert.That(() => _reservation.CanBeCancelledBy(_reservation.MadeBy), Is.True);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUser_ReturnFalse()
        {
            _reservation.MadeBy = _user;

            Assert.That(() => _reservation.CanBeCancelledBy(new User()), Is.False);
        }

        [Test]
        public void CanBeCancelledBy_IsAdmin_ReturnTrue()
        {
            _user.IsAdmin = true;

            Assert.That(() => _reservation.CanBeCancelledBy(_user), Is.True);
        }
    }
}

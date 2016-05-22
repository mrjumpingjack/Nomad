using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace surveillance
{
    class Lenkachsen_AI
    {
        double angle_to_turn;
        double start_angle;
        bool dodged = true;


        //Program.datamng.antrieb Program.datamng.antrieb = new Program.datamng.antrieb();

        public double GetAngle(GPSpoint p1, GPSpoint p2)
        {

            double xDiff = p2.lat - p1.lat;
            double yDiff = p2.lng - p1.lng;
            return Math.Atan2(yDiff, xDiff) * (180 / Math.PI);

        }

        void aim(GPSpoint target)
        {
            try
            {
                start_angle = GetAngle(Program.datamng.quopoint, target);

                Console.WriteLine("START ANGLE: " + start_angle);

                if(Program.datamng.Orientation - start_angle <= 180)
                {//gegen uhrzeigersinn
                    angle_to_turn = Program.datamng.Orientation - start_angle;


                    while (Math.Abs(angle_to_turn) != Program.datamng.angle_approach)
                    {
                        angle_to_turn = Program.datamng.Orientation - start_angle;
                        Program.datamng.antrieb.turn_right();
                        Thread.Sleep(100);
                        Program.datamng.antrieb.stopp();
                        Thread.Sleep(100);
                        Console.WriteLine("ANGLE TO TURN: " + angle_to_turn);
                        if (target != Program.datamng.targetpoint)
                        {
                          Console.WriteLine("TARGET CHANGED!");
                          Console.WriteLine("OLD:" + target.lat + "," + target.lng);
                          target = Program.datamng.targetpoint;
                          Console.WriteLine("New:" + target.lat + "," + target.lng);

                          Console.WriteLine("OLD START ANGLE:" + start_angle);
                          start_angle = GetAngle(Program.datamng.quopoint, target);
                          Console.WriteLine("NEW START ANGLE:" + start_angle);

                          Console.WriteLine("OLD ANGLE TO TURN:" + angle_to_turn);
                          angle_to_turn = Program.datamng.Orientation - start_angle;
                          Console.WriteLine("OLD ANGLE TO TURN:" + angle_to_turn);
                        }

                    }


                }
                else
                {//mit uhrzeigersinn
                    angle_to_turn = 360 - (Program.datamng.Orientation - start_angle);

                    while (Math.Abs(angle_to_turn) != Program.datamng.angle_approach)
                    {
                        angle_to_turn = 360 - (Program.datamng.Orientation - start_angle);
                        Program.datamng.antrieb.turn_left();
                        Thread.Sleep(100);
                        Program.datamng.antrieb.stopp();
                        Thread.Sleep(100);
                        Console.WriteLine("ANGLE TO TURN: " + angle_to_turn);

                        if (target != Program.datamng.targetpoint)
                        {
                            Console.WriteLine("TARGET CHANGED!");
                            Console.WriteLine("OLD POINT:" + target.lat + "," + target.lng);
                            target = Program.datamng.targetpoint;
                            Console.WriteLine("New POINT:" + target.lat + "," + target.lng);

                            Console.WriteLine("OLD START ANGLE:" + start_angle);
                            start_angle = GetAngle(Program.datamng.quopoint, target);
                            Console.WriteLine("NEW START ANGLE:" + start_angle);

                            Console.WriteLine("OLD ANGLE TO TURN:" + angle_to_turn);
                            angle_to_turn = 360 - (Program.datamng.Orientation - start_angle);
                            Console.WriteLine("OLD ANGLE TO TURN:" + angle_to_turn);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE AIMING: " + Convert.ToString(target.lat) + "," + Convert.ToString(target.lng));
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        public double DistanceTo(GPSpoint me, GPSpoint target, char unit = 'K')
        {
            try
            {
                if (me != null && target != null)
                {
                    double rlat1 = Math.PI * me.lat / 180;
                    double rlat2 = Math.PI * target.lat / 180;
                    double theta = me.lng - target.lng;
                    double rtheta = Math.PI * theta / 180;
                    double dist =
                        Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                        Math.Cos(rlat2) * Math.Cos(rtheta);
                    dist = Math.Acos(dist);
                    dist = dist * 180 / Math.PI;
                    dist = dist * 60 * 1.1515;

                    switch (unit)
                    {
                        case 'K': //Kilometers -> default
                            return dist * 1.609344;
                        case 'M': //Meters
                            return (dist * 1.609344) * 1000;
                    }

                    return dist;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE GETTING A DISTANCE");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                return 0;
            }
        }

        private void turn_angle(double angle, char d)
        {
            try
            {
                double start_Orientation = Program.datamng.Orientation;
                double end_Orientation;

                if (start_Orientation + angle <= 360)
                {
                    end_Orientation = start_Orientation + angle;
                }
                else
                {
                    end_Orientation = (start_Orientation + angle) - 360;

                }
                if (d == 'R')
                {
                    //im UZS
                    while (Program.datamng.Orientation <= (end_Orientation + Program.datamng.angle_approach) || Program.datamng.Orientation >= (end_Orientation - Program.datamng.angle_approach))
                    {
                        Program.datamng.antrieb.turn_right();
                        Thread.Sleep(100);
                        Program.datamng.antrieb.stopp();
                        Thread.Sleep(100);

                    }
                }
                else
                {
                    //gegen UZS
                    while (Program.datamng.Orientation <= (end_Orientation + Program.datamng.angle_approach) || Program.datamng.Orientation >= (end_Orientation - Program.datamng.angle_approach))
                    {

                        while (angle_to_turn != 0)
                        {
                            Program.datamng.antrieb.turn_right();
                            Thread.Sleep(100);
                            Program.datamng.antrieb.stopp();
                            Thread.Sleep(100);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE TURNING " + Convert.ToString(angle));
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        private void turn_till_sensor_free(Sensor sensor, char d, double max_degr)
        {
            try
            {
                double drehung = 0;
                double lcAngle = Program.datamng.Orientation;

                while (sensor.abstand <= 200)
                {
                    if (d == 'R')
                    {
                        Program.datamng.antrieb.turn_left();
                    }
                    else
                    {
                        Program.datamng.antrieb.turn_right();
                    }

                    Thread.Sleep(100);
                    Program.datamng.antrieb.stopp();
                    Thread.Sleep(100);

                    drehung = Math.Abs(Program.datamng.Orientation - lcAngle);

                    if (drehung > max_degr)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE TURNING TILL SENSOR FREE");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

        }

        private void turn_till_sensor_abstand(Sensor sensor, int abstand, int max_grad, char d)
        {
            try
            {
                double start_Orientation = Program.datamng.Orientation;
                double end_Orientation;
                //bool grad_ok = true;

                if (start_Orientation + max_grad <= 360)
                {
                    end_Orientation = start_Orientation + max_grad;
                }
                else
                {
                    end_Orientation = (start_Orientation + max_grad) - 360;

                }




                if (d == 'R')
                {
                    //FAIL
                    while (sensor.abstand <= (abstand + Program.datamng.dis_approach) && sensor.abstand >= (abstand - Program.datamng.dis_approach))
                    {

                        Program.datamng.antrieb.turn_right();
                        Thread.Sleep(100);
                        Program.datamng.antrieb.stopp();
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    while (sensor.abstand <= (abstand + Program.datamng.dis_approach) && sensor.abstand >= (abstand - Program.datamng.dis_approach))
                    {
                        Program.datamng.antrieb.turn_left();
                        Thread.Sleep(100);
                        Program.datamng.antrieb.stopp();
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE TURNING TILL SENSOR GOT DISTANCE");
                Console.WriteLine(ex.Message);
                Console.WriteLine();

            }
        }

        private void turn_till_Sensor_sensor_equal(Sensor sens1, Sensor sens2)
        {
            try
            {
                float abstand = 0.0f;

                if (sens1.abstand < sens2.abstand)
                {
                    abstand = (float)(sens2.abstand - sens1.abstand);
                }
                else
                {
                    abstand = (float)(sens1.abstand - sens2.abstand);
                }

                while (abstand > 2)
                {

                    if (sens1.abstand < sens2.abstand)
                    {

                        Program.datamng.antrieb.turn_right();

                    }
                    else
                    {
                        Program.datamng.antrieb.turn_left();
                    }
                    Thread.Sleep(100);
                    Program.datamng.antrieb.stopp();
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE TURNING TILL SENSORS EQUAL");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        private void drive_by(char s)
        {
            try
            {
                if (s == 'R')
                {

                    while (Program.datamng.Sensoren[2].abstand <= 10 && Program.datamng.Sensoren[5].abstand <= 10)
                    {
                        Program.datamng.antrieb.forwards();
                        Thread.Sleep(500);
                        Program.datamng.antrieb.stopp();
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    while (Program.datamng.Sensoren[1].abstand <= 10 && Program.datamng.Sensoren[4].abstand <= 10)
                    {
                        Program.datamng.antrieb.forwards();
                        Thread.Sleep(500);
                        Program.datamng.antrieb.stopp();
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE DRIVING BY");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

        }





        private void dodge_obsticle(int dodge)
        {
            try
            {
                dodged = false;
                switch (dodge)
                {
                    case 0:
                        //Kein Hinderniss
                        Program.datamng.antrieb.forwards();
                        break;

                    case 1:
                        //Fronales Flächenhinderniss
                        Program.datamng.antrieb.stopp();
                        turn_angle(90, 'R');
                        drive_by('L');
                        break;

                    case 2:
                        //Fronal_Links Flächenhinderniss
                        turn_till_sensor_free(Program.datamng.Sensoren[0], 'R', 180);
                        break;

                    case 3:
                        //Fronal_Links Flächenhinderniss
                        turn_till_sensor_free(Program.datamng.Sensoren[0], 'L', 180);
                        break;

                    case 4:
                        //Hinten Flächenhinderniss
                        Program.datamng.antrieb.stopp();
                        break;

                    case 5:
                        //Ganz Rechts Flächenhinderniss
                        drive_by('R');
                        Program.datamng.antrieb.stopp();
                        break;

                    case 6:
                        //Ganz Links Flächenhinderniss
                        drive_by('L');
                        Program.datamng.antrieb.stopp();
                        break;

                    case 7:
                        //Vorne_Links_Ecke
                        turn_angle(90, 'R');
                        drive_by('L');
                        Program.datamng.antrieb.stopp();
                        break;

                    case 8:
                        //Vorne_Rechts_Ecke
                        turn_angle(90, 'L');
                        drive_by('R');
                        Program.datamng.antrieb.stopp();
                        break;

                    case 9:
                        //Hinten_Links_Ecke
                        turn_angle(90, 'R');
                        Program.datamng.antrieb.stopp();
                        break;

                    case 10:
                        //Hinten_Rechts_Ecke
                        turn_angle(90, 'R');
                        Program.datamng.antrieb.stopp();
                        break;

                    case 11:
                        //Hinten_Links Flächenhinderniss
                        Program.datamng.antrieb.stopp();
                        break;

                    case 12:
                        //Hinten_Rechts Flächenhinderniss
                        Program.datamng.antrieb.stopp();
                        break;

                    case 13:
                        //Passage

                        turn_till_Sensor_sensor_equal(Program.datamng.Sensoren[1], Program.datamng.Sensoren[2]);
                        //ODER
                        //turn_till_Sensor_sensor_equal("Vorn_Links", "Hinten_Links");

                        Program.datamng.antrieb.forwards();
                        break;

                    case 14:
                        //Punkt_Frontal_rechts
                        Program.datamng.antrieb.stopp();
                        turn_till_sensor_free(Program.datamng.Sensoren[2], 'L', 45);
                        break;

                    case 15:
                        //Punkt_Frontal
                        Program.datamng.antrieb.stopp();
                        turn_till_sensor_free(Program.datamng.Sensoren[0], 'L', 45);
                        break;

                    case 16:
                        //Punkt_Frontal_Links
                        Program.datamng.antrieb.stopp();
                        turn_till_sensor_free(Program.datamng.Sensoren[1], 'R', 45);
                        break;

                    case 17:
                        //Punkt_Hinten_Rechts
                        Program.datamng.antrieb.stopp();
                        drive_by('R');
                        break;

                    case 18:
                        //Punkt_Hinten_Links
                        Program.datamng.antrieb.stopp();
                        drive_by('L');
                        break;

                    case 19:
                        //Punkt_Hinten
                        Program.datamng.antrieb.stopp();
                        break;
                }



                dodged = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE DODGING AN OBSTICLE");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        public void moves()
        {
            try
            {
                while (true)
                {

                    while (Program.datamng.quopoint.lat == 0 && Program.datamng.quopoint.lng == 0)
                    {
                        Console.WriteLine("ERROR QOUPOINT IS NOT SET: " + Program.datamng.quopoint.lat + ";" + Program.datamng.quopoint.lng);
                        Thread.Sleep(2000);
                    }
      
                    while (DistanceTo(Program.datamng.quopoint, Program.datamng.targetpoint, 'M') >= Program.datamng.dis_approach)
                    {
                        Console.WriteLine(Convert.ToString(DistanceTo(Program.datamng.quopoint, Program.datamng.targetpoint, 'M')));

                        if (dodged)
                        {
                            Program.datamng.antrieb.stopp();

                            if (Program.datamng.qoupoint_changed.AddSeconds(30) <= DateTime.Now)
                            {
                                GPSpoint last_qp= Program.datamng.quopoint;
                                while (last_qp == Program.datamng.quopoint)
                                {
                                    Console.WriteLine("ERROR QOUPOINT TO OLD: " + Program.datamng.quopoint.lat + ";" + Program.datamng.quopoint.lng);
                                    Thread.Sleep(2000);
                                }
                            }

                            Console.WriteLine("AIMING...");
                            aim(Program.datamng.targetpoint);
                            Console.WriteLine("AIMING DONE");

                            if (Program.datamng.Sensoren[1].abstand == Program.datamng.max_distance &&
                                Program.datamng.Sensoren[0].abstand == Program.datamng.max_distance &&
                                Program.datamng.Sensoren[2].abstand == Program.datamng.max_distance &&
                                Program.datamng.Sensoren[4].abstand == Program.datamng.max_distance &&
                                Program.datamng.Sensoren[5].abstand == Program.datamng.max_distance &&
                                Program.datamng.Sensoren[3].abstand == Program.datamng.max_distance)
                            {
                                //Kein Hinderniss, weiterfahren
                                dodge_obsticle(0);
                            }

                            if (Program.datamng.Sensoren[1].abstand <= 30 &&
                                Program.datamng.Sensoren[0].abstand <= 10 &&
                                Program.datamng.Sensoren[2].abstand <= 30 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Fronales Flächenhinderniss
                                dodge_obsticle(1);
                            }

                            if (Program.datamng.Sensoren[1].abstand <= 15 &&
                                Program.datamng.Sensoren[0].abstand <= 20 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Fronal_Links Flächenhinderniss
                                dodge_obsticle(2);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand <= 20 &&
                                Program.datamng.Sensoren[2].abstand <= 15 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Fronal_Rechts Flächenhinderniss
                                dodge_obsticle(3);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand <= 30 &&
                                Program.datamng.Sensoren[5].abstand <= 30 &&
                                Program.datamng.Sensoren[3].abstand <= 10)
                            {
                                //Hinten Flächenhinderniss
                                dodge_obsticle(4);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand <= 30 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand <= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Ganz Rechts Flächenhinderniss
                                dodge_obsticle(5);
                            }

                            if (Program.datamng.Sensoren[1].abstand <= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand <= 30 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Ganz Links Flächenhinderniss
                                dodge_obsticle(6);
                            }

                            if (Program.datamng.Sensoren[1].abstand <= 30 &&
                                Program.datamng.Sensoren[0].abstand <= 30 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand <= 30 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Vorne_Links_Ecke
                                dodge_obsticle(7);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand <= 30 &&
                                Program.datamng.Sensoren[2].abstand <= 30 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand <= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Vorne_Rechts_Ecke
                                dodge_obsticle(8);
                            }

                            if (Program.datamng.Sensoren[1].abstand <= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand <= 30 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand <= 30)
                            {
                                //Hinten_Links_Ecke
                                dodge_obsticle(9);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand <= 30 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand <= 30 &&
                                Program.datamng.Sensoren[3].abstand <= 30)
                            {
                                //Hinten_Rechts_Ecke
                                dodge_obsticle(10);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand <= 15 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand <= 20)
                            {
                                //Hinten_Links Flächenhinderniss
                                dodge_obsticle(11);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand <= 15 &&
                                Program.datamng.Sensoren[3].abstand <= 20)
                            {
                                //Hinten_Rechts Flächenhinderniss
                                dodge_obsticle(12);
                            }

                            if (Program.datamng.Sensoren[1].abstand <= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand <= 30 &&
                                Program.datamng.Sensoren[4].abstand <= 30 &&
                                Program.datamng.Sensoren[5].abstand <= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Passage
                                dodge_obsticle(13);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand <= 10 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Punkt_Frontal_Rechts
                                dodge_obsticle(14);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand <= 10 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Punkt_Frontal
                                dodge_obsticle(15);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                               Program.datamng.Sensoren[0].abstand >= 30 &&
                               Program.datamng.Sensoren[2].abstand >= 30 &&
                               Program.datamng.Sensoren[4].abstand <= 10 &&
                               Program.datamng.Sensoren[5].abstand >= 30 &&
                               Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Punkt_Frontal_Links
                                dodge_obsticle(16);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand <= 10 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Punkt_Frontal_Rechts
                                dodge_obsticle(17);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand <= 10 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand >= 30)
                            {
                                //Punkt_Frontal_Links
                                dodge_obsticle(18);
                            }

                            if (Program.datamng.Sensoren[1].abstand >= 30 &&
                                Program.datamng.Sensoren[0].abstand >= 30 &&
                                Program.datamng.Sensoren[2].abstand >= 30 &&
                                Program.datamng.Sensoren[4].abstand >= 30 &&
                                Program.datamng.Sensoren[5].abstand >= 30 &&
                                Program.datamng.Sensoren[3].abstand <= 10)
                            {
                                //Punkt_Hinten
                                dodge_obsticle(19);
                            }

                        }


                        Thread.Sleep(100);
                    }

                    Program.datamng.targetpoint = Program.datamng.route[Program.datamng.next_way_point];
                    Program.datamng.next_way_point++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE MOVING");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
    }
}

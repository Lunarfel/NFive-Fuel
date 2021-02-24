using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunarfel.LunarfelFuel.Client.Helpers
{
	public static class GasStations
	{
		public static Vector3[] positions;
		public static Vector3[][] pumps;

		private static bool AreGasStationsLoaded = false;

		/// <summary>
		/// Loads the 'positions' and 'pumps' arrays with the data from 'GasStations.json'.
		/// Could use some improvements in the future, but it works for now.
		/// </summary>
		public static void LoadGasStations()
		{
			if (!AreGasStationsLoaded)
			{
				// load the GasStations.json file.
				string jsonString = "{\"GasStations\":[{\"coordinates\":{\"X\":49.418720245361328,\"Y\":2778.79296875,\"Z\":58.043949127197266},\"pumps\":[{\"X\":49.499210357666016,\"Y\":2778.912109375,\"Z\":58.043991088867188}]},{\"coordinates\":{\"X\":263.8948974609375,\"Y\":2606.462890625,\"Z\":44.983390808105469},\"pumps\":[{\"X\":263.17318725585938,\"Y\":2606.514892578125,\"Z\":44.9852409362793},{\"X\":265.07391357421875,\"Y\":2606.89990234375,\"Z\":44.9852409362793}]},{\"coordinates\":{\"X\":1039.9580078125,\"Y\":2671.134033203125,\"Z\":39.550910949707031},\"pumps\":[{\"X\":1043.2860107421875,\"Y\":2668.31591796875,\"Z\":39.6953010559082},{\"X\":1035.779052734375,\"Y\":2667.884033203125,\"Z\":39.598419189453125},{\"X\":1035.363037109375,\"Y\":2674.14599609375,\"Z\":39.6953010559082},{\"X\":1043.22802734375,\"Y\":2674.72705078125,\"Z\":39.692588806152344}]},{\"coordinates\":{\"X\":1207.260009765625,\"Y\":2660.175048828125,\"Z\":37.899959564208984},\"pumps\":[{\"X\":1208.802978515625,\"Y\":2659.409912109375,\"Z\":38.292949676513672},{\"X\":1209.3819580078125,\"Y\":2658.550048828125,\"Z\":38.292961120605469},{\"X\":1206.1639404296875,\"Y\":2662.242919921875,\"Z\":38.292961120605469}]},{\"coordinates\":{\"X\":2539.68505859375,\"Y\":2594.19189453125,\"Z\":37.944881439208984},\"pumps\":[{\"X\":2540.0458984375,\"Y\":2594.929931640625,\"Z\":37.941139221191406}]},{\"coordinates\":{\"X\":2679.85791015625,\"Y\":3263.946044921875,\"Z\":55.240570068359375},\"pumps\":[{\"X\":2680.89208984375,\"Y\":3266.343994140625,\"Z\":55.156509399414062},{\"X\":2678.446044921875,\"Y\":3262.31201171875,\"Z\":55.156818389892578}]},{\"coordinates\":{\"X\":2005.0550537109375,\"Y\":3773.886962890625,\"Z\":32.4039306640625},\"pumps\":[{\"X\":2009.2080078125,\"Y\":3776.83203125,\"Z\":32.147579193115234},{\"X\":2006.240966796875,\"Y\":3775.010009765625,\"Z\":32.1514892578125},{\"X\":2003.9210205078125,\"Y\":3773.583984375,\"Z\":32.14501953125},{\"X\":2001.4840087890625,\"Y\":3772.196044921875,\"Z\":32.146701812744141}]},{\"coordinates\":{\"X\":1687.156005859375,\"Y\":4929.39208984375,\"Z\":42.078090667724609},\"pumps\":[{\"X\":1684.635986328125,\"Y\":4931.69580078125,\"Z\":41.929531097412109},{\"X\":1690.1689453125,\"Y\":4927.81591796875,\"Z\":41.919490814208984}]},{\"coordinates\":{\"X\":1701.31396484375,\"Y\":6416.02783203125,\"Z\":32.763950347900391},\"pumps\":[{\"X\":1701.72900390625,\"Y\":6416.4228515625,\"Z\":32.988300323486328},{\"X\":1697.7020263671875,\"Y\":6418.27587890625,\"Z\":32.396610260009766},{\"X\":1705.75,\"Y\":6414.47607421875,\"Z\":32.471309661865234}]},{\"coordinates\":{\"X\":179.8572998046875,\"Y\":6602.8388671875,\"Z\":31.8681697845459},\"pumps\":[{\"X\":172.11669921875,\"Y\":6603.4599609375,\"Z\":31.767589569091797},{\"X\":179.74920654296875,\"Y\":6604.9619140625,\"Z\":31.750480651855469},{\"X\":187.04389953613281,\"Y\":6606.25390625,\"Z\":31.751010894775391}]},{\"coordinates\":{\"X\":-94.461990356445312,\"Y\":6419.59423828125,\"Z\":31.489519119262695},\"pumps\":[{\"X\":-97.033683776855469,\"Y\":6416.826171875,\"Z\":31.386800765991211},{\"X\":-91.3159408569336,\"Y\":6422.505859375,\"Z\":31.342670440673828}]},{\"coordinates\":{\"X\":-2554.99609375,\"Y\":2334.402099609375,\"Z\":33.078029632568359},\"pumps\":[{\"X\":-2551.4208984375,\"Y\":2327.216064453125,\"Z\":33.017440795898438},{\"X\":-2558.01806640625,\"Y\":2327.195068359375,\"Z\":33.078041076660156},{\"X\":-2558.60791015625,\"Y\":2334.410888671875,\"Z\":32.963539123535156},{\"X\":-2552.719970703125,\"Y\":2334.7060546875,\"Z\":32.972648620605469},{\"X\":-2552.409912109375,\"Y\":2341.948974609375,\"Z\":33.005199432373047},{\"X\":-2558.843017578125,\"Y\":2340.989013671875,\"Z\":33.010990142822266}]},{\"coordinates\":{\"X\":-1800.375,\"Y\":803.66192626953125,\"Z\":138.65119934082031},\"pumps\":[{\"X\":-1796.2939453125,\"Y\":811.601806640625,\"Z\":138.50579833984375},{\"X\":-1790.8709716796875,\"Y\":806.37408447265625,\"Z\":138.20289611816406},{\"X\":-1797.1510009765625,\"Y\":800.720703125,\"Z\":138.38909912109375},{\"X\":-1802.280029296875,\"Y\":806.30792236328125,\"Z\":138.37510681152344},{\"X\":-1808.656982421875,\"Y\":799.99041748046875,\"Z\":138.427001953125},{\"X\":-1803.636962890625,\"Y\":794.51141357421875,\"Z\":138.40969848632813}]},{\"coordinates\":{\"X\":-1437.6219482421875,\"Y\":-276.74758911132812,\"Z\":46.207710266113281},\"pumps\":[{\"X\":-1444.3399658203125,\"Y\":-274.1885986328125,\"Z\":46.119308471679688},{\"X\":-1435.3900146484375,\"Y\":-284.62548828125,\"Z\":46.122360229492188},{\"X\":-1428.98095703125,\"Y\":-278.96749877929688,\"Z\":46.108089447021484},{\"X\":-1438.0030517578125,\"Y\":-268.39871215820312,\"Z\":46.075351715087891}]},{\"coordinates\":{\"X\":-2096.242919921875,\"Y\":-320.28671264648438,\"Z\":13.168569564819336},\"pumps\":[{\"X\":-2089.239990234375,\"Y\":-327.372802734375,\"Z\":13.028949737548828},{\"X\":-2088.4560546875,\"Y\":-320.83160400390625,\"Z\":12.974220275878906},{\"X\":-2087.032958984375,\"Y\":-312.79739379882812,\"Z\":12.906490325927734},{\"X\":-2095.93310546875,\"Y\":-311.92739868164062,\"Z\":12.90725040435791},{\"X\":-2096.466064453125,\"Y\":-320.41830444335938,\"Z\":13.028849601745606},{\"X\":-2097.3359375,\"Y\":-326.397705078125,\"Z\":12.88916015625},{\"X\":-2105.950927734375,\"Y\":-325.5889892578125,\"Z\":12.935210227966309},{\"X\":-2105.10302734375,\"Y\":-319.01840209960938,\"Z\":12.877900123596191},{\"X\":-2104.419921875,\"Y\":-311.00900268554688,\"Z\":12.933449745178223}]},{\"coordinates\":{\"X\":-724.61920166015625,\"Y\":-935.1630859375,\"Z\":19.213859558105469},\"pumps\":[{\"X\":-715.043212890625,\"Y\":-932.56378173828125,\"Z\":19.07505989074707},{\"X\":-715.4774169921875,\"Y\":-939.2255859375,\"Z\":19.350490570068359},{\"X\":-723.8599853515625,\"Y\":-939.2935791015625,\"Z\":18.862829208374023},{\"X\":-723.7554931640625,\"Y\":-932.4473876953125,\"Z\":19.402450561523438},{\"X\":-732.39312744140625,\"Y\":-932.56280517578125,\"Z\":19.413459777832031},{\"X\":-732.469970703125,\"Y\":-939.54620361328125,\"Z\":18.945060729980469}]},{\"coordinates\":{\"X\":-526.019775390625,\"Y\":-1211.0030517578125,\"Z\":18.184829711914062},\"pumps\":[{\"X\":-518.49932861328125,\"Y\":-1209.4429931640625,\"Z\":18.077829360961914},{\"X\":-521.27471923828125,\"Y\":-1208.4019775390625,\"Z\":18.061979293823242},{\"X\":-526.128173828125,\"Y\":-1206.4019775390625,\"Z\":18.068170547485352},{\"X\":-528.5460205078125,\"Y\":-1204.93798828125,\"Z\":18.089929580688477},{\"X\":-532.3411865234375,\"Y\":-1212.7740478515625,\"Z\":18.075939178466797},{\"X\":-529.4605712890625,\"Y\":-1213.782958984375,\"Z\":18.075889587402344},{\"X\":-524.92578125,\"Y\":-1216.4420166015625,\"Z\":18.039810180664062},{\"X\":-522.18072509765625,\"Y\":-1217.3709716796875,\"Z\":18.076009750366211}]},{\"coordinates\":{\"X\":-70.21484375,\"Y\":-1761.7919921875,\"Z\":29.534019470214844},\"pumps\":[{\"X\":-63.784229278564453,\"Y\":-1767.8070068359375,\"Z\":29.5849609375},{\"X\":-61.2121696472168,\"Y\":-1760.782958984375,\"Z\":29.573970794677734},{\"X\":-69.465591430664062,\"Y\":-1758.156982421875,\"Z\":29.255090713500977},{\"X\":-72.028778076171875,\"Y\":-1765.1300048828125,\"Z\":29.238740921020508},{\"X\":-80.310966491699219,\"Y\":-1762.1650390625,\"Z\":29.508279800415039},{\"X\":-77.669830322265625,\"Y\":-1755.0770263671875,\"Z\":29.527690887451172}]},{\"coordinates\":{\"X\":265.64840698242188,\"Y\":-1261.3089599609375,\"Z\":29.292940139770508},\"pumps\":[{\"X\":273.88919067382812,\"Y\":-1268.60595703125,\"Z\":29.508960723876953},{\"X\":273.91018676757812,\"Y\":-1261.3409423828125,\"Z\":29.458410263061523},{\"X\":273.9552001953125,\"Y\":-1253.5550537109375,\"Z\":29.004629135131836},{\"X\":265.08810424804688,\"Y\":-1253.458984375,\"Z\":29.534889221191406},{\"X\":264.59759521484375,\"Y\":-1261.260986328125,\"Z\":29.443119049072266},{\"X\":265.19259643554688,\"Y\":-1268.5030517578125,\"Z\":29.069480895996094},{\"X\":256.46160888671875,\"Y\":-1268.6259765625,\"Z\":29.551509857177734},{\"X\":256.51739501953125,\"Y\":-1261.2869873046875,\"Z\":28.948049545288086},{\"X\":256.47250366210938,\"Y\":-1253.448974609375,\"Z\":29.557689666748047}]},{\"coordinates\":{\"X\":819.65380859375,\"Y\":-1028.845947265625,\"Z\":26.403419494628906},\"pumps\":[{\"X\":826.75128173828125,\"Y\":-1026.1650390625,\"Z\":26.357280731201172},{\"X\":826.7982177734375,\"Y\":-1030.967041015625,\"Z\":26.429569244384766},{\"X\":819.14111328125,\"Y\":-1030.9969482421875,\"Z\":26.229820251464844},{\"X\":819.15008544921875,\"Y\":-1026.3690185546875,\"Z\":26.181209564208984},{\"X\":810.82037353515625,\"Y\":-1026.366943359375,\"Z\":26.151189804077148},{\"X\":810.8690185546875,\"Y\":-1031.196044921875,\"Z\":26.158199310302734}]},{\"coordinates\":{\"X\":1208.9510498046875,\"Y\":-1402.5670166015625,\"Z\":35.224189758300781},\"pumps\":[{\"X\":1210.22705078125,\"Y\":-1407.06494140625,\"Z\":35.114448547363281},{\"X\":1213.0069580078125,\"Y\":-1404.0789794921875,\"Z\":35.095840454101562},{\"X\":1207.0810546875,\"Y\":-1398.2960205078125,\"Z\":35.157279968261719},{\"X\":1204.208984375,\"Y\":-1401.1009521484375,\"Z\":35.131858825683594}]},{\"coordinates\":{\"X\":1181.3809814453125,\"Y\":-330.84710693359375,\"Z\":69.316513061523438},\"pumps\":[{\"X\":1186.4560546875,\"Y\":-338.14840698242188,\"Z\":69.5254135131836},{\"X\":1179.0550537109375,\"Y\":-339.394287109375,\"Z\":69.6856689453125},{\"X\":1177.467041015625,\"Y\":-331.177490234375,\"Z\":68.971786499023438},{\"X\":1184.803955078125,\"Y\":-329.97158813476562,\"Z\":69.489906311035156},{\"X\":1183.2239990234375,\"Y\":-321.36898803710938,\"Z\":69.195938110351562},{\"X\":1175.6429443359375,\"Y\":-322.26959228515625,\"Z\":68.982192993164062}]},{\"coordinates\":{\"X\":620.8433837890625,\"Y\":269.10089111328125,\"Z\":103.08950042724609},\"pumps\":[{\"X\":629.555419921875,\"Y\":263.85690307617188,\"Z\":103.02239990234375},{\"X\":629.37908935546875,\"Y\":273.95458984375,\"Z\":102.99870300292969},{\"X\":620.789794921875,\"Y\":273.88861083984375,\"Z\":102.99880218505859},{\"X\":612.34820556640625,\"Y\":274.08468627929688,\"Z\":103.00430297851563},{\"X\":612.27130126953125,\"Y\":263.88848876953125,\"Z\":102.99179840087891},{\"X\":620.9271240234375,\"Y\":263.83108520507812,\"Z\":103.02510070800781}]},{\"coordinates\":{\"X\":2581.321044921875,\"Y\":362.039306640625,\"Z\":108.46880340576172},\"pumps\":[{\"X\":2588.462890625,\"Y\":358.53900146484375,\"Z\":108.39579772949219},{\"X\":2589.12890625,\"Y\":363.90438842773438,\"Z\":108.39949798583984},{\"X\":2581.26611328125,\"Y\":364.24551391601562,\"Z\":108.39980316162109},{\"X\":2581.087890625,\"Y\":358.8944091796875,\"Z\":108.37239837646484},{\"X\":2573.717041015625,\"Y\":359.02780151367188,\"Z\":108.36150360107422},{\"X\":2573.843994140625,\"Y\":364.69720458984375,\"Z\":108.39579772949219}]},{\"coordinates\":{\"X\":1785.363037109375,\"Y\":3330.3720703125,\"Z\":41.381881713867188},\"pumps\":[{\"X\":1785.89501953125,\"Y\":3330.16796875,\"Z\":41.345619201660156},{\"X\":1785.14501953125,\"Y\":3331.251953125,\"Z\":41.381229400634766}]},{\"coordinates\":{\"X\":-319.69000244140625,\"Y\":-1471.6099853515625,\"Z\":30.030000686645508},\"pumps\":[{\"X\":-310.3699951171875,\"Y\":-1472.030029296875,\"Z\":30.719999313354492},{\"X\":-315.45999145507812,\"Y\":-1463.27001953125,\"Z\":30.719999313354492},{\"X\":-321.79998779296875,\"Y\":-1467.030029296875,\"Z\":30.719999313354492},{\"X\":-316.67999267578125,\"Y\":-1475.93994140625,\"Z\":30.719999313354492},{\"X\":-324.22000122070312,\"Y\":-1480.1700439453125,\"Z\":30.719999313354492},{\"X\":-329.30999755859375,\"Y\":-1471.3499755859375,\"Z\":30.719999313354492}]},{\"coordinates\":{\"X\":174.8800048828125,\"Y\":-1562.449951171875,\"Z\":28.739999771118164},\"pumps\":[{\"X\":169.64999389648438,\"Y\":-1562.6800537109375,\"Z\":29.319999694824219},{\"X\":176.41999816894531,\"Y\":-1556.280029296875,\"Z\":29.319999694824219},{\"X\":181.38999938964844,\"Y\":-1561.56005859375,\"Z\":29.319999694824219},{\"X\":174.63999938964844,\"Y\":-1567.68994140625,\"Z\":29.319999694824219}]},{\"coordinates\":{\"X\":1246.47998046875,\"Y\":-1485.449951171875,\"Z\":34.900001525878906},\"pumps\":[{\"X\":1246.1600341796875,\"Y\":-1488.1500244140625,\"Z\":34.900001525878906},{\"X\":1246.47998046875,\"Y\":-1482.760009765625,\"Z\":34.900001525878906}]},{\"coordinates\":{\"X\":-66.330001831054688,\"Y\":-2532.570068359375,\"Z\":6.1399998664855957},\"pumps\":[{\"X\":-64.25,\"Y\":-2533.89990234375,\"Z\":6.1399998664855957},{\"X\":-68.720001220703125,\"Y\":-2530.7099609375,\"Z\":6.1399998664855957}]}]}";
				if (string.IsNullOrEmpty(jsonString))
				{
					// Do not continue if the file is empty or it's null.
					Debug.WriteLine("[FRFuel] An error occurred while loading the gas stations file.");
					return;
				}

				// Convert the json into an object.
				Newtonsoft.Json.Linq.JObject jsonData = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(jsonString);

				int i = 0;

				Newtonsoft.Json.Linq.JArray gasStations = (Newtonsoft.Json.Linq.JArray)jsonData["GasStations"];

				// Initialize the 'positions' and 'pumps' Vector3 Arrays.
				positions = new Vector3[gasStations.Count];
				pumps = new Vector3[gasStations.Count][];

				// Go through every gas station in the json data, and create a location entry for it.
				// Then go through all the pumps for that gas station and add all the pump vector3's to the pumps Array.
				foreach (var gasStation in gasStations)
				{
					Vector3 location = new Vector3(
						float.Parse(gasStation["coordinates"]["X"].ToString()),
						float.Parse(gasStation["coordinates"]["Y"].ToString()),
						float.Parse(gasStation["coordinates"]["Z"].ToString())
						);

					positions[i] = location;

					Newtonsoft.Json.Linq.JArray pumpsList = (Newtonsoft.Json.Linq.JArray)gasStation["pumps"];
					pumps[i] = new Vector3[pumpsList.Count];
					for (int p = 0; p < pumpsList.Count; p++)
					{
						pumps[i][p] = new Vector3(
							float.Parse(pumpsList[p]["X"].ToString()),
							float.Parse(pumpsList[p]["Y"].ToString()),
							float.Parse(pumpsList[p]["Z"].ToString())
							);
					}
					i++;
				}

				// Prevent this function from being accidentally called twice for whatever reason.
				AreGasStationsLoaded = true;
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommandUndoRedo;
using UnityEngine;
using UnityEngine.Rendering;

namespace RuntimeGizmos
{
	[RequireComponent(typeof(Camera))]
	public class TransformGizmo : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CForceUpdatePivotPointAtEndOfFrame_003Ed__128 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public TransformGizmo _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CForceUpdatePivotPointAtEndOfFrame_003Ed__128(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CTransformSelected_003Ed__109 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public TransformGizmo _003C_003E4__this;

			public TransformType transType;

			[NonSerialized]
			public Vector3 _003CoriginalPivot_003E5__2;

			[NonSerialized]
			public Vector3 _003CotherAxis1_003E5__3;

			[NonSerialized]
			public Vector3 _003CotherAxis2_003E5__4;

			[NonSerialized]
			public Vector3 _003Caxis_003E5__5;

			[NonSerialized]
			public Vector3 _003CplaneNormal_003E5__6;

			[NonSerialized]
			public Vector3 _003CprojectedAxis_003E5__7;

			[NonSerialized]
			public Vector3 _003CpreviousMousePosition_003E5__8;

			[NonSerialized]
			public Vector3 _003CcurrentSnapMovementAmount_003E5__9;

			[NonSerialized]
			public float _003CcurrentSnapRotationAmount_003E5__10;

			[NonSerialized]
			public float _003CcurrentSnapScaleAmount_003E5__11;

			[NonSerialized]
			public List<ICommand> _003CtransformCommands_003E5__12;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CTransformSelected_003Ed__109(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public TransformSpace space;

		public TransformType transformType;

		public TransformPivot pivot;

		public CenterType centerType;

		public ScaleType scaleType;

		public Color xColor;

		public Color yColor;

		public Color zColor;

		public Color allColor;

		public Color selectedColor;

		public Color hoverColor;

		public float planesOpacity;

		public bool isSnapping;

		public float movementSnap;

		public float rotationSnap;

		public float scaleSnap;

		public float handleLength;

		public float handleWidth;

		public float planeSize;

		public float triangleSize;

		public float boxSize;

		public int circleDetail;

		public float allMoveHandleLengthMultiplier;

		public float allRotateHandleLengthMultiplier;

		public float allScaleHandleLengthMultiplier;

		public float minSelectedDistanceCheck;

		public float moveSpeedMultiplier;

		public float scaleSpeedMultiplier;

		public float rotateSpeedMultiplier;

		public float allRotateSpeedMultiplier;

		public bool useFirstSelectedAsMain;

		public bool circularRotationMethod;

		public bool forceUpdatePivotPointOnChange;

		public LayerMask selectionMask;

		public Action onCheckForSelectedAxis;

		public Action onDrawCustomGizmo;

		[NonSerialized]
		public Vector3 totalCenterPivotPoint;

		[NonSerialized]
		public AxisInfo axisInfo;

		[NonSerialized]
		public AxisVectors handleLines;

		[NonSerialized]
		public AxisVectors handlePlanes;

		[NonSerialized]
		public AxisVectors handleTriangles;

		[NonSerialized]
		public AxisVectors handleSquares;

		[NonSerialized]
		public AxisVectors circlesLines;

		public List<Transform> targetRootsOrdered;

		[NonSerialized]
		public Dictionary<Transform, TargetInfo> targetRoots;

		[NonSerialized]
		public HashSet<Renderer> highlightedRenderers;

		[NonSerialized]
		public HashSet<Transform> children;

		[NonSerialized]
		public List<Transform> childrenBuffer;

		[NonSerialized]
		public List<Renderer> renderersBuffer;

		[NonSerialized]
		public List<Material> materialsBuffer;

		[NonSerialized]
		public WaitForEndOfFrame waitForEndOFFrame;

		[NonSerialized]
		public Coroutine forceUpdatePivotCoroutine;

		public static Material lineMaterial;

		public static Material outlineMaterial;

		public Camera myCamera { get; set; }

		public bool isTransforming { get; set; }

		public float totalScaleAmount { get; set; }

		public Quaternion totalRotationAmount { get; set; }

		public Axis translatingAxis { get; set; }

		public Axis translatingAxisPlane { get; set; }

		public bool hasTranslatingAxisPlane => false;

		public TransformType transformingType { get; set; }

		public Vector3 pivotPoint { get; set; }

		public Transform mainTargetRoot => null;

		public void Awake()
		{
		}

		public void RenderPipelineManager_endFrameRendering(ScriptableRenderContext context, Camera[] camera)
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void OnDestroy()
		{
		}

		public void Update()
		{
		}

		public void LateUpdate()
		{
		}

		public void OnPostRender()
		{
		}

		public Color GetColor(TransformType type, Color normalColor, Color nearColor, bool forceUseNormal = false)
		{
			return default(Color);
		}

		public Color GetColor(TransformType type, Color normalColor, Color nearColor, float alpha, bool forceUseNormal = false)
		{
			return default(Color);
		}

		public Color GetColor(TransformType type, Color normalColor, Color nearColor, bool setAlpha, float alpha, bool forceUseNormal = false)
		{
			return default(Color);
		}

		public void HandleUndoRedo()
		{
		}

		public TransformSpace GetProperTransformSpace()
		{
			return default(TransformSpace);
		}

		public bool TransformTypeContains(TransformType type)
		{
			return false;
		}

		public bool TranslatingTypeContains(TransformType type, bool checkIsTransforming = true)
		{
			return false;
		}

		public bool TransformTypeContains(TransformType mainType, TransformType type)
		{
			return false;
		}

		public float GetHandleLength(TransformType type, Axis axis = Axis.None, bool multiplyDistanceMultiplier = true)
		{
			return 0f;
		}

		public void SetSpaceAndType()
		{
		}

		public void TransformSelected()
		{
		}

		[IteratorStateMachine(typeof(_003CTransformSelected_003Ed__109))]
		public IEnumerator TransformSelected(TransformType transType)
		{
			return null;
		}

		public float CalculateSnapAmount(float snapValue, float currentAmount, out float remainder)
		{
			remainder = default(float);
			return 0f;
		}

		public Vector3 GetNearAxisDirection(out Vector3 otherAxis1, out Vector3 otherAxis2)
		{
			otherAxis1 = default(Vector3);
			otherAxis2 = default(Vector3);
			return default(Vector3);
		}

		public void GetTarget()
		{
		}

		public void AddTarget(Transform target, bool addCommand = true)
		{
		}

		public void RemoveTarget(Transform target, bool addCommand = true)
		{
		}

		public void ClearTargets(bool addCommand = true)
		{
		}

		public void ClearAndAddTarget(Transform target)
		{
		}

		public void AddTargetHighlightedRenderers(Transform target)
		{
		}

		public void GetTargetRenderers(Transform target, List<Renderer> renderers)
		{
		}

		public void ClearAllHighlightedRenderers()
		{
		}

		public void RemoveTargetHighlightedRenderers(Transform target)
		{
		}

		public void RemoveHighlightedRenderers(List<Renderer> renderers)
		{
		}

		public void AddTargetRoot(Transform targetRoot)
		{
		}

		public void RemoveTargetRoot(Transform targetRoot)
		{
		}

		public void AddAllChildren(Transform target)
		{
		}

		public void RemoveAllChildren(Transform target)
		{
		}

		public void SetPivotPoint()
		{
		}

		public void SetPivotPointOffset(Vector3 offset)
		{
		}

		[IteratorStateMachine(typeof(_003CForceUpdatePivotPointAtEndOfFrame_003Ed__128))]
		public IEnumerator ForceUpdatePivotPointAtEndOfFrame()
		{
			return null;
		}

		public void ForceUpdatePivotPointOnChange()
		{
		}

		public void SetTranslatingAxis(TransformType type, Axis axis, Axis planeAxis = Axis.None)
		{
		}

		public AxisInfo GetAxisInfo()
		{
			return default(AxisInfo);
		}

		public void SetNearAxis()
		{
		}

		public void HandleNearestLines(TransformType type, AxisVectors axisVectors, float minSelectedDistanceCheck)
		{
		}

		public void HandleNearestPlanes(TransformType type, AxisVectors axisVectors, float minSelectedDistanceCheck)
		{
		}

		public void HandleNearest(TransformType type, float xClosestDistance, float yClosestDistance, float zClosestDistance, float allClosestDistance, float minSelectedDistanceCheck)
		{
		}

		public float ClosestDistanceFromMouseToLines(List<Vector3> lines)
		{
			return 0f;
		}

		public float ClosestDistanceFromMouseToPlanes(List<Vector3> planePoints)
		{
			return 0f;
		}

		public void SetAxisInfo()
		{
		}

		public float GetDistanceMultiplier()
		{
			return 0f;
		}

		public void SetLines()
		{
		}

		public void SetHandleLines()
		{
		}

		public int AxisDirectionMultiplier(Vector3 direction, Vector3 otherDirection)
		{
			return 0;
		}

		public void SetHandlePlanes()
		{
		}

		public void SetHandleTriangles()
		{
		}

		public void AddTriangles(Vector3 axisEnd, Vector3 axisDirection, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float size, List<Vector3> resultsBuffer)
		{
		}

		public void SetHandleSquares()
		{
		}

		public void AddSquares(Vector3 axisStart, Vector3 axisDirection, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float size, List<Vector3> resultsBuffer)
		{
		}

		public void AddQuads(Vector3 axisStart, Vector3 axisDirection, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float length, float width, List<Vector3> resultsBuffer)
		{
		}

		public void AddQuads(Vector3 axisStart, Vector3 axisEnd, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float width, List<Vector3> resultsBuffer)
		{
		}

		public void AddQuad(Vector3 axisStart, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float width, List<Vector3> resultsBuffer)
		{
		}

		public Square GetBaseSquare(Vector3 axisEnd, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float size)
		{
			return default(Square);
		}

		public void SetCircles(AxisInfo axisInfo, AxisVectors axisVectors)
		{
		}

		public void AddCircle(Vector3 origin, Vector3 axisDirection, float size, List<Vector3> resultsBuffer, bool depthTest = true)
		{
		}

		public void DrawLines(List<Vector3> lines, Color color)
		{
		}

		public void DrawTriangles(List<Vector3> lines, Color color)
		{
		}

		public void DrawQuads(List<Vector3> lines, Color color)
		{
		}

		public void DrawFilledCircle(List<Vector3> lines, Color color)
		{
		}

		public void SetMaterial()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
